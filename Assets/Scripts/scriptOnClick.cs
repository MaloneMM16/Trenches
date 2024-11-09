using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptOnClick : MonoBehaviour
{
    public static int activeObj;

    public void ChangeObj()
    {
        if (gameObject.tag == "MG")
        {
            activeObj = 1;
        }

        if (gameObject.tag == "FH")
        {
            activeObj = 2;
        }

        if (gameObject.tag == "AT")
        {
            activeObj = 3;
        }
        Debug.Log(activeObj);
    }
}
