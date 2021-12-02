using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textbox : MonoBehaviour
{
    
    int curtext = 0;
    public GameObject texbox;
    public void DoText(object[,] text)
    {
        string line = text[curtext, 0] as string;
        string icon = text[curtext, 1] as string;
        bool CanEnd = (bool) text[curtext, 2];

        print((icon, line, CanEnd));
        if (CanEnd)
        {
            curtext = 0;
        }
        else
        {
            curtext += 1;
        }
    }
}
