using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string[] text;
    public Sprite[] icons;


    // Update is called once per frame
    void Update()
    {
        
    }
    public string[] InterAct()
    {
        return text;
    }
    public Sprite[] geticons()
    {
        return icons;
    }
}
