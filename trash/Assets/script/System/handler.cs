using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handler : MonoSingleton<handler>
{
    //manager
    public SideWalkManager sideWalkManager;
    public Camera came;
    public int game_full_time;
    public int second_per_person;
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
            if(game_time%second_per_person==0)
            {
                int temp=Random.Range(0,3);
                float random_width=Random.Range(-came.sensorSize.x/4,came.sensorSize.x/4);
                bool right;
                TrashType type=TrashType.normal;
                switch(temp)
                {
                    case 0:
                        type=TrashType.normal;
                        break;
                    case 1:
                        type=TrashType.recycle;
                        break;
                    case 2:
                        type=TrashType.waste;
                        break;
                }
                temp=Random.Range(0,2);
                if(temp==0)
                    right=false;
                else
                    right=true;
                sideWalkManager.CreatePerson(type,right,random_width*Vector2.right);
                //生成一個隨機的行人
                //傳入3個參數
                //確定左邊/右邊、丟垃圾的位置,的垃圾類型
            }
            second=0;
        }
        ShowGameTime();
        sideWalkManager.DetectThrow();
    }
    
    public void InitGameTime(){
        this.game_time = game_full_time;
    }

    ///顯示遊戲當前時間
    public void ShowGameTime(){
        Timer_text.text = this.Game_Time.ToString() + "秒";
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
