using UnityEngine;
using System.Collections;
using System;

public class Converting : MonoBehaviour
{
    public static int ConvertStringToInt(string textToConvert)
    {
        int x = 0;

        if (Int32.TryParse(textToConvert, out x))
        {
            return x;
        }
        else
        {
            Debug.LogError(textToConvert + " was not an int!");
            return 0;
        }
    }
}
