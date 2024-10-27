using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toss : MonoBehaviour
{
    public float timeToToss = 9.5f;
    public float timeToFire = 1.5f;
    public float tossForce = 15f;
    public float slowMotionScale = 0.7f;
    public float fireSpreadScale = 1f;
    public GameObject fire;

    private bool thrown = false;
    private Rigidbody rb;

    [SerializeField]
    AudioSource fireSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeToToss -= Time.deltaTime;

        if (!thrown)
        {
            

            if (timeToToss <= 0)
            {
                thrown = true;

                rb.isKinematic = false;
                rb.AddForce(new Vector3 (tossForce, 0, 0), ForceMode.Impulse);
                transform.parent = null;

                Time.timeScale = slowMotionScale;

            }
        }
        else
        {
            if (!fire.activeInHierarchy)
            {
                if (timeToToss <= (0 - timeToFire))
                {
                    rb.isKinematic = true;
                    fire.SetActive(true);

                    fireSFX.Play();
                }
            }
            else
            {
                if (timeToToss >= (0 - timeToFire * fireSpreadScale * 2))
                {
                    fire.transform.localScale = Vector3.one * (0 - timeToToss) * fireSpreadScale;

                }
                    
            }
            
        }
        

        
    }


}
