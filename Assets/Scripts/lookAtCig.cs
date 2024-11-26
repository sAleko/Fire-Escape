using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class lookAtCig : MonoBehaviour
{
    public GameObject cig;
    public float zoomMultiplier = 4f;
    public float zoomOutToNextScene = 2f;
    public float fadeOutTime = 1f;
    public bool startInCar = true;
    public GameObject rabbit;
    
    private float timeToToss;
    private float timeToFire;
    private float sceneTrigger = 0f;
    private bool nextScene = false;
    private Camera cam;
    private Camera cigCam;
    private FadeIn fadeIn;

    void Start()
    {
        cam = GetComponent<Camera>();
        cigCam = cig.GetComponentInChildren<Camera>();
        fadeIn = GetComponent<FadeIn>();

        if (!startInCar)
        {
            cigCam.enabled = false;
            cam.enabled = true;
        }

        rabbit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeToToss = cig.GetComponent<toss>().timeToToss;
        timeToFire = cig.GetComponent<toss>().timeToFire;

        transform.LookAt(cig.transform);
        
        if (timeToToss <= 0 && timeToToss > (0 - timeToFire) && cam.fieldOfView > 20)
        {
            
            if (startInCar && cigCam.enabled && !cam.enabled)
            {
                cigCam.enabled = false;
                cam.enabled = true;
                
            }
            cam.fieldOfView -= zoomMultiplier * Time.deltaTime;
        }

        if (timeToToss <= (0 - timeToFire))
        {
            if (cam.fieldOfView < 60)
            {
                rabbit.SetActive(true);
                cam.fieldOfView += zoomMultiplier * Time.deltaTime;
            } else
            {
                if (sceneTrigger == 0)
                {
                    sceneTrigger = timeToToss - zoomOutToNextScene;
                } 
                else if (!nextScene && timeToToss < sceneTrigger)
                {
                    nextScene = true;
                    StartCoroutine(FadeOut());
                }

            }

        }


        //Debug.Log("Time to toss: " + timeToToss);
    }

    IEnumerator FadeOut()
    {
        StartCoroutine(fadeIn.Fading(fadeOutTime));
        yield return new WaitForSecondsRealtime(fadeOutTime);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
