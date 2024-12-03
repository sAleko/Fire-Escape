using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StopSmoDmgTrigger : MonoBehaviour
{
    public Boolean trigger = false;
    
    GameObject rabbit;
    // Start is called before the first frame update
    // void Start()
    // {
    //     player = rabbit.GetComponent<Health>();
    // }

    // Update is called once per frame
    void Update()
    {
        if (trigger == true)
        {
            rabbit.GetComponent<Health>().beInSmoke = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        trigger = true;
    }
}
