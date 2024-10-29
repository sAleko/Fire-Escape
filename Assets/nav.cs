using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class nav : MonoBehaviour
{
    public float displayTime = 15f; // Duration the text will be visible
    private float currentTime;
    [SerializeField] TextMeshProUGUI textComponent;

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
