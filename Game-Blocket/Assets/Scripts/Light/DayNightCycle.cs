using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Rendering;

public class DayNightCycle : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D globalLight;

    //cannot be over 60[min] 
    public static int Daylength = 3;

    public static int Seconds { get => DateTime.Now.TimeOfDay.Seconds; }
    public static int Minutes { get => DateTime.Now.TimeOfDay.Minutes; }
    //iwie komplett falsch lul 
    public static float inGameSeconds { get => (24f/Daylength/100f*60)*(float)Seconds; }

    public static int inGameMinutes { get => umrechner(); }

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        calcInGameTime();
    }

    /// <summary>
    /// Calculates the In Game Time based on the actual RealLife-Daytime
    /// </summary>
    public void calcInGameTime()
    {
        // Lightincrease per sec = 1/(daylength[min] * 60[sec])
        float lightStrength =  Mathf.RoundToInt(inGameMinutes)/24f;
        globalLight.intensity = lightStrength; 

    }

    public static int umrechner()
    {
        int s = Minutes;
        while (s > Daylength)
        {
            s -= Daylength;
        }
        return Mathf.FloorToInt(24f / Daylength)*s;
    }
}
