using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTimer : MonoBehaviour
{
    /// <summary>
    /// Bruh berni daf�r eine eigene Klasse?
    /// </summary>
    void Update()
    {
        GetComponent<Text>().text = Mathf.RoundToInt(DayNightCycle.inGameMinutes) +"h";
    }
}
