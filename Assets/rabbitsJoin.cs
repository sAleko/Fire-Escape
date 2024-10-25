using FiveRabbitsDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbitsJoin : MonoBehaviour
{
    public rabbitsJoin player;

    public bool loverStart = false;

    private Animator anim;
    private bool loverStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && !loverStarted)
        {
            if (player.loverStart)
            {
                loverStarted = true;
                loverStart = true;
                anim.enabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lover Start"))
        {
            anim.enabled = true;
            loverStart = true;
        }
        else if (other.CompareTag("Stop"))
        {
            anim.Rebind();
            anim.Update(0f);
            anim.enabled = false;
        }
    }
}
