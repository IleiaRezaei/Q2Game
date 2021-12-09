using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textbox : MonoBehaviour
{
    
    int curtext = 0;
    private GameObject texobj;
    bool end;
    public string jsonpath;
    private void Start()
    {
        this.gameObject.SetActive(false);
        texobj = transform.GetChild(0).gameObject;
    }
    public void DoText(object[,] text)
    {
        if (end == false)
        {
            this.gameObject.SetActive(true);
            string line = text[curtext, 0] as string;
            int icon = (int)text[curtext, 1];
            bool CanEnd = (bool)text[curtext, 2];

            print((icon, line, CanEnd));
            texobj.GetComponent<Text>().text = line;

            if (CanEnd)
            {
                end = true;

            }
            else
            {
                curtext += 1;
            }
        }
        else
        {
            
            end = false;
            curtext = 0;
            this.gameObject.SetActive(false);

        }
    }
}
