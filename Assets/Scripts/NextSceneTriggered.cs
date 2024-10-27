using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTriggered : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
