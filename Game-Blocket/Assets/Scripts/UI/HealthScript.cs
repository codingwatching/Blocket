using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] [Range(10,200)]
    public float maxHealth;
    [SerializeField] [Range(0, 200)]
    public float currentHealth;
    
    [SerializeField] 
    private Sprite Heart;
    [SerializeField]
    private Sprite half_Heart;

    [SerializeField] 
    private GameObject HeartSlot1;
    [SerializeField] 
    private GameObject HeartSlot2;
    
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (currentHealth > 75)
        {
            HeartSlot1.gameObject.GetComponent<Image>().sprite = Heart;
            HeartSlot1.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            HeartSlot2.gameObject.GetComponent<Image>().sprite = Heart;
            HeartSlot2.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else if (currentHealth > 50)
        {
            HeartSlot1.gameObject.GetComponent<Image>().sprite = Heart;
            HeartSlot1.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            HeartSlot2.gameObject.GetComponent<Image>().sprite = half_Heart;
            HeartSlot2.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else if (currentHealth > 25)
        {
            HeartSlot1.gameObject.GetComponent<Image>().sprite = Heart;
            HeartSlot1.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            HeartSlot2.gameObject.GetComponent<Image>().sprite = null;
            HeartSlot2.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
        else if (currentHealth > 0)
        {
            HeartSlot1.gameObject.GetComponent<Image>().sprite = half_Heart;
            HeartSlot1.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            HeartSlot2.gameObject.GetComponent<Image>().sprite = null;
            HeartSlot2.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
        else if (currentHealth >= 0)
        {
            HeartSlot1.gameObject.GetComponent<Image>().sprite = null;
            HeartSlot1.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            HeartSlot2.gameObject.GetComponent<Image>().sprite = null;
            HeartSlot2.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
    }
}
