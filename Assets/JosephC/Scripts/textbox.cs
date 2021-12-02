using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textbox : MonoBehaviour
{
    
    int curtext = 0;
    GameObject texobj;
    private void Start()
    {
        texobj = transform.GetChild(0).gameObject;
    }
    public void DoText(object[,] text)
    {
        string line = text[curtext, 0] as string;
        int icon = (int) text[curtext, 1];
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
