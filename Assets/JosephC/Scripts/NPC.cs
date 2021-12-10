using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public object[,] text = { { "hi", 0, false }, { "so sad", 1, true } };
    public Sprite[] icons;
    //public string jsonpath;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    if (jsonpath != null)
    //    {
    //        text = new object[1,1];
    //        int l = 0;
    //        foreach (string line in System.IO.File.ReadLines(jsonpath))
    //        {
    //            print(line);
    //            DiaImpJsonClass d = new DiaImpJsonClass();
    //            d = JsonUtility.FromJson<DiaImpJsonClass>(line);
    //            print(d);
    //            l += 1;
    //        }
    //    }
        
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
    public object[,] InterAct()
    {
        return text;
    }
    public Sprite[] geticons()
    {
        return icons;
    }
}
