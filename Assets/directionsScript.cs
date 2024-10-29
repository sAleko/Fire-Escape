using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class directionsScript : MonoBehaviour
{
    public float displayTime = 5f; // Duration the text will be visible
    private float currentTime;
    public TextMesh textComponent;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = displayTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)

        {

            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0); // Make text transparent

        }
    }
}
