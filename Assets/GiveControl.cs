using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveControl : MonoBehaviour
{
    public GameObject player;
    public GameObject cutSceneRab;
    public GameObject cutSceneCam;


    // Start is called before the first frame update
    void Start()
    {
        cutSceneCam.SetActive(true);
        cutSceneRab.SetActive(true);
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cutSceneCam.SetActive(false);
            cutSceneRab.SetActive(false);
            player.SetActive(true);
        }
    }
}
