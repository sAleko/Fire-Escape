using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float fireDamage = 15f;
    public float smokeDamage = 3f;
    public float health;
    public float knockback = 2f;
    public float deathScreenLength = 4f;
    public bool beInSmoke;
    public bool stopDamage;
    public Image healthBar;
    public GameObject deathScreen;

    private Rigidbody rabbitBody;
    private Animator rAnim;
    private BasicBehaviour bb;
    private MoveBehaviour mb;
    private FlyBehaviour fb;
    private bool dying = false;


    // Start is called before the first frame update
    void Start()
    {
        rabbitBody = GetComponent<Rigidbody>();
        rAnim = GetComponent<Animator>();

        bb = GetComponent<BasicBehaviour>();
        mb = GetComponent<MoveBehaviour>();
        fb = GetComponent<FlyBehaviour>();

        health = maxHealth;

        deathScreen.SetActive(false);
    }

    void Update() {
        if (beInSmoke == true){
            health -= Time.deltaTime * smokeDamage;
            healthBar.fillAmount = health / maxHealth;
        }

        if (!dying && health <= 0)
        {
            StartCoroutine("Die");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("Fire")) return;

        health -= fireDamage;
        healthBar.fillAmount = health / maxHealth;
                

        if (!dying)
        {
            Vector3 closestPoint = other.ClosestPoint(transform.position);
            Vector3 pointToPlayer = (transform.position - closestPoint).normalized;
            // Debug.Log("Closest contact point: " + closestPoint);
            // Debug.Log("Vector pointing towards rabbit from contact point: " + (transform.position - closestPoint).normalized);

            // Vector3 knockbackForce = (rabbitBody.velocity * -1 * knockback);
            Vector3 knockbackForce = (pointToPlayer * knockback);
            knockbackForce.y = 0f;

            rabbitBody.AddForce(knockbackForce, ForceMode.Impulse);
            transform.LookAt(transform.position + pointToPlayer);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Smoke"))
        {
            beInSmoke = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Smoke"))
        {
            beInSmoke = false;
        }
    }

    IEnumerator Die()
    {
        dying = true;
        healthBar.fillAmount = 0;
        deathScreen.SetActive(true);

        bb.enabled = mb.enabled = fb.enabled = false;

        rAnim.Play("Base Layer.Dead", 0);

        yield return new WaitForSeconds(deathScreenLength);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
