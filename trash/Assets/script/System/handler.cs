using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handler : MonoSingleton<handler>
{
    public int game_full_time;
    public Text Timer_text;
    public Text Score;
    double second=0;
    private int game_time=0;
    public int Game_Time{
        get{return game_time;}
    }
    // Start is called before the first frame update
    void Start()
    {
        InitGameTime();
    }

    // Update is called once per frame
    void Update()
    {
        second+=Time.deltaTime;
        if(second>=1)
        {
            game_time-=1;
            second=0;
        }
        ShowGameTime();
    }
    public void InitGameTime(){
        this.game_time = game_full_time;
    }

    ///顯示遊戲當前時間
    public void ShowGameTime(){
        Timer_text = this.Game_Time.ToString() + "秒";
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
