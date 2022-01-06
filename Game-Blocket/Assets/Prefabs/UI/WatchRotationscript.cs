using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchRotationscript : MonoBehaviour
{
    public GameObject hourCounter;
    int oldhour;
    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < Mathf.FloorToInt(DayNightCycle.inGameMinutes); i++)
        {
            hourCounter.transform.Rotate(0, 0, (1 / 24f) * 360f);
        }
        oldhour = DayNightCycle.inGameMinutes;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (oldhour != Mathf.FloorToInt(DayNightCycle.inGameMinutes))
        {
            if(oldhour < Mathf.FloorToInt(DayNightCycle.inGameMinutes))
            {
                int difference = Mathf.FloorToInt(DayNightCycle.inGameMinutes) - oldhour;
                while(difference > 0)
                {
                    hourCounter.transform.Rotate(0, 0, (1 / 24f) * 360f);
                    difference--;
                }
            }
            oldhour = DayNightCycle.inGameMinutes;
            hourCounter.transform.Rotate(0, 0, (1 / 24f) * 360f);
        }
        Debug.Log(((DayNightCycle.inGameMinutes / 24f) * 360f));
    }


}
