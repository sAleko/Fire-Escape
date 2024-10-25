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
    public Image healthBar;

    private Rigidbody rabbitBody;


    // Start is called before the first frame update
    void Start()
    {
        rabbitBody = GetComponent<Rigidbody>();

        health = maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Fire")) return;

        health -= fireDamage;
        healthBar.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            healthBar.fillAmount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Vector3 knockbackForce = (rabbitBody.velocity * -1 * knockback);
            knockbackForce.y = 0f;

            rabbitBody.AddForce(knockbackForce, ForceMode.Impulse);
            transform.Rotate(new Vector3(0, -180, 0));
        }


    }
}
