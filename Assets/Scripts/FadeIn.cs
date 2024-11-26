using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image fadeScreen;
    public float fadeInSeconds = -1f;

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
        float absTime = Mathf.Abs(fadeSeconds);

        while (absTime > 0)
        {
            fadeScreen.color = new Color(0, 0, 0, 
                (fadeScreen.color.a + (Time.unscaledDeltaTime * 1f / fadeSeconds)));

            absTime -= Time.unscaledDeltaTime;
            yield return null;
        }
    }

}
