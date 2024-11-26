using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTriggered : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        StartCoroutine(FadeOut(other.gameObject.GetComponent<FadeIn>()));
        
    }

    private IEnumerator FadeOut(FadeIn fadeIn)
    {
        float fadeSec = fadeIn.fadeInSeconds;

        StartCoroutine(fadeIn.Fading(-fadeSec));
        yield return new WaitForSecondsRealtime(Mathf.Abs(fadeSec));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
