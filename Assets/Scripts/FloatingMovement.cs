using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 goal;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 pos = transform.position;
        pos.x += 500f;
        goal = pos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce((goal - transform.position).normalized * speed);

    }
}
