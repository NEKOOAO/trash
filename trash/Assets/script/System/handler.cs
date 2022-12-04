using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handler : MonoSingleton<handler>
{
    public Text Timer;
    public Text Score;
    double second=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        second+=Time.deltaTime;
        if(second>=1)
        {
            int temp=int.Parse(Timer.text);
            temp--;
            Timer.text=temp.ToString();
            second=0;
        }
    }
    
    public void AddScore()
    {
        ChangeScore(1);
    }
    public void MinusScore()
    {
        ChangeScore(-1);
    }
    private void ChangeScore(int change)
    {
        int temp=int.Parse(Score.text);
        temp+=change;
        Score.text=temp.ToString();
    }
}
