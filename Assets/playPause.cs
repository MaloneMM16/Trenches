using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playPause : MonoBehaviour
{
    public static int timeScale = 0;

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void togglePause()
    {
        timeScale++;
        if (timeScale >= 3)
        {
            timeScale = 0;
        }

        if (timeScale == 0)
        {
            Time.timeScale = 0f;
        }
        else if (timeScale == 1)
        {
            Time.timeScale = 1f;
        }
        else if (timeScale == 2)
        {
            Time.timeScale = 2f;
        }
    }
}
