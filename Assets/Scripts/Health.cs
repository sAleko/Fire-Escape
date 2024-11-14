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
    public float health;
    public float knockback = 2f;
    public float deathScreenLength = 4f;
    public Image healthBar;
    public GameObject deathScreen;

    private Rigidbody rabbitBody;
    private Animator rAnim;
    private BasicBehaviour bb;
    private MoveBehaviour mb;
    private FlyBehaviour fb;


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

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Fire")) return;

        health -= fireDamage;
        healthBar.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            StartCoroutine("Die");
        }
        else
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

    IEnumerator Die()
    {
        healthBar.fillAmount = 0;
        deathScreen.SetActive(true);

        bb.enabled = mb.enabled = fb.enabled = false;

        rAnim.Play("Base Layer.Dead", 0);

        yield return new WaitForSeconds(deathScreenLength);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
