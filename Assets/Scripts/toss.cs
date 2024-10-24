using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toss : MonoBehaviour
{
    public float timeToToss = 9.5f;
    public float tossForce = 15f;
    private bool thrown = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!thrown)
        {
            timeToToss -= Time.deltaTime;

            if (timeToToss <= 0)
            {
                thrown = true;
                
                rb.isKinematic = false;
                rb.AddForce(new Vector3 (tossForce, 0, 0), ForceMode.Impulse);
                transform.parent = null;

            }
        }
        

        
    }
}
