using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EventS : MonoBehaviour
{
    public Text timer,counter;
    double i=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        i+=Time.deltaTime;
        if(i>=1)
        {
            Debug.Log(i);
            int temp=Convert.ToInt32(timer.text);
            temp--;
            i=0;
            timer.text=temp.ToString();
        }
    }
}
