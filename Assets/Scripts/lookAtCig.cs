using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCig : MonoBehaviour
{
    public GameObject cig;
    public float zoomMultiplier = 4f;
    public bool startInCar = true;
    public GameObject rabbit;
    
    private float timeToToss;
    private float timeToFire;
    private Camera cam;
    private Camera cigCam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cigCam = cig.GetComponentInChildren<Camera>();

        if (!startInCar)
        {
            cigCam.enabled = false;
            cam.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeToToss = cig.GetComponent<toss>().timeToToss;
        timeToFire = cig.GetComponent<toss>().timeToFire;

        transform.LookAt(cig.transform);
        
        if (timeToToss <= 0 && timeToToss > (0 - timeToFire) && cam.fieldOfView > 20)
        {
            
            if (startInCar && cigCam.enabled && !cam.enabled)
            {
                cigCam.enabled = false;
                cam.enabled = true;
                
            }
            cam.fieldOfView -= zoomMultiplier * Time.deltaTime;
        }

        if (timeToToss <= (0 - timeToFire) && cam.fieldOfView < 60)
        {
            rabbit.SetActive(true);
            cam.fieldOfView += zoomMultiplier * Time.deltaTime;
            //Debug.Log("working: " + (zoomMultiplier * Time.deltaTime));
        }

        //Debug.Log("Time to toss: " + timeToToss);
    }
}
