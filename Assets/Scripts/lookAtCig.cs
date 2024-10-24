using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCig : MonoBehaviour
{
    public GameObject cig;
    public float zoomMultiplier = 4f;
    public bool startInCar = true;
    
    private float timeToToss;
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
        transform.LookAt(cig.transform);
        
        if (timeToToss <= 0 && cam.fieldOfView > 20)
        {
            if (startInCar && cigCam.enabled && !cam.enabled)
            {
                cigCam.enabled = false;
                cam.enabled = true;
            }
            cam.fieldOfView -= zoomMultiplier * Time.deltaTime;
        }
    }
}
