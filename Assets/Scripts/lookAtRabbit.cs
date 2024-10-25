using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class lookAtRabbit : MonoBehaviour
{
    public GameObject rab;
    public float zoomMult = 1f;
    public float delayToZoom = 5f;

    private Camera cam;
    private bool startZooming = false;

    void Start()
    {
        cam = GetComponent<Camera>();
        Debug.Log(Vector3.Distance(transform.position, rab.transform.position));
        StartCoroutine("Zoom");
    }

    IEnumerator Zoom()
    {
        yield return new WaitForSeconds(delayToZoom);
        startZooming = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(rab.transform);

        if (startZooming)
            cam.fieldOfView = zoomMult * 60f / Vector3.Distance(transform.position, rab.transform.position);



        //Debug.Log("Time to toss: " + timeToToss);
    }
}
