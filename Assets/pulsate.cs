using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulsate : MonoBehaviour
{
    public float frequency = 1f;
    public float amplitude = 1f;
    public float offset = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scale = (Mathf.Sin(Time.time * frequency) * amplitude) + offset;
        transform.localScale = new Vector3(scale, scale * 0.5f, transform.localScale.z);
    }
}
