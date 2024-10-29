using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;



public class TreeFallTrigger : MonoBehaviour
{
    public Rigidbody treeRb;
    public bool testFall = false;

    public AudioSource treeFallsfx;

    [SerializeField] TextMeshProUGUI textComponent;
    public Boolean trigger = false;
    // Start is called before the first frame update

   void Update()
    {
        if (trigger)
        {
            textComponent.color = new Color(1f, 1f, 0f, textComponent.color.a);
            Color currentColor = textComponent.color;
            currentColor.a = Mathf.Min(currentColor.a + Time.deltaTime, 1f); // Increase alpha until it's fully visible
            textComponent.color = currentColor;
        }
    }
    void Start()
    {
        treeRb.isKinematic = !testFall;
        textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        treeFallsfx.Play();

        trigger = true;

        treeRb.isKinematic = false;
    }
}
