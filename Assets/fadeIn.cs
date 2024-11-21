using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour
{
    public Image fadeScreen;
    public float fadeInSeconds = 1f;
    public float fadeMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fading(fadeInSeconds));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Fading(float fadeSeconds)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeSeconds)
        {
            fadeScreen.color = new Color(0, 0, 0, 
                (1f / elapsedTime));

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

}
