using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFallTrigger : MonoBehaviour
{
    public Rigidbody treeRb;
    public bool testFall = false;

    // Start is called before the first frame update
    void Start()
    {
        treeRb.isKinematic = !testFall;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        treeRb.isKinematic = false;
    }
}
