using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSticks : MonoBehaviour
{
    public Vector3[] positions = new Vector3[] 
    {
        new Vector3(-2.95001221f, 0, -19.1000366f),
        new Vector3(-8.35003662f,0,-12.9000244f), 
        new Vector3(-3.05004883f,0,-4.5f),
        new Vector3(-3.05004883f,0,-4.5f)
    };

    public Vector3[] rotations = new Vector3[]
    {
        new Vector3(0,130f,0),
        new Vector3(0,246.110565f,0),
        new Vector3(0,202.287949f,0),
        new Vector3(0,202.287949f,0)
    };

    public GameObject stick;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < positions.Length; i++) {
            GameObject currentStick = Instantiate(stick);
            currentStick.transform.position = positions[i];
            currentStick.transform.rotation = Quaternion.Euler(rotations[i]);
            currentStick.transform.SetParent(transform);
        }
    }
}
