using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class truckDrive : MonoBehaviour
{

    [SerializeField]
    private Transform endTrans;
    [SerializeField]
    private float wheelRadius = 0.356f;
    private float wheelCircumference;
    private float wheelRotPerSec;

    public float speed = 1f;
    public GameObject[] wheels;

    void Start()
    {
        wheelCircumference = 2 * Mathf.PI * wheelRadius;
        
    }

    void Update()
    {
        //Move Truck
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, endTrans.position, step);

        wheelRotPerSec = speed / wheelCircumference;
        foreach (var wheel in wheels)
        {
            wheel.transform.Rotate(new Vector3(wheelRotPerSec * -360f * Time.deltaTime, 0, 0));
        }

    }
}
