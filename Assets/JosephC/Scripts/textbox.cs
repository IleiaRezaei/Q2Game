using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textbox : MonoBehaviour
{
    
    int curtext = 0;
    private GameObject texobj;
    bool end;
    private Animator anim;
    private GameObject ico;
    public string jsonpath;
    private bool dialogue;
    private void Start()
    {
        texobj = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
        ico = transform.GetChild(1).gameObject;
    }
    public void DoText(object[,] text, Sprite[] pic)
    {
        if (end == false)
        {
            if (dialogue != true)
            {
                anim.Play("TextboxOpen");
                dialogue = true;
                
            }
            string line = text[curtext, 0] as string;
            int icon = (int)text[curtext, 1];
            bool CanEnd = (bool)text[curtext, 2];

            

            print((icon, line, CanEnd));
            ico.GetComponent<Image>().sprite = pic[icon];
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
            anim.Play("TextboxClose");
            dialogue = false;
        }
    }
}
