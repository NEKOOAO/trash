using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mannger : MonoBehaviour
{
    /*-------------------------
        now_can  -> now colide can's ID(1>2>3)
        hold_can -> now hold can's ID
        incan    -> is in can?
        holding  -> is holding can?
        canarr   -> can_mannger array, operate push and hold
     --------------------------*/

    private Vector2 pos;
    private int now_can = 0, hold_can;
    private bool incan1, incan2, incan3, holding = false;
    public can_mannger[] canarr = new can_mannger[3];

    //init var
    void Start()
    {
        incan1 = false;
        incan2 = false;
        incan3 = false;
    }
    //set is incan? 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "trash_can1") incan1 = true;
        if (collision.gameObject.name == "trash_can2") incan2 = true;
        if (collision.gameObject.name == "trash_can3") incan3 = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "trash_can1") incan1 = false;
        if (collision.gameObject.name == "trash_can2") incan2 = false;
        if (collision.gameObject.name == "trash_can3") incan3 = false;
    }
 

    void Update()
    {
        //set now colide can
        if (incan1) now_can = 1;
        else if (incan2) now_can = 2;
        else if (incan3) now_can = 3;
        else now_can = 0;

        //set pos
        pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow) && pos.x>-8.15f)
        {
            transform.position = new Vector2(pos.x - 10 * Time.deltaTime, pos.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && pos.x<8.15f)
        {
            transform.position = new Vector2(pos.x + 10 * Time.deltaTime, pos.y);
        }

        //push and hold
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (holding) push_can(); //if holding anything try push it
            else take_up_can();      //if not holding take it
        }
    }

    //hold now colide can
    void take_up_can() { 
        if (now_can != 0)
        {
            canarr[now_can - 1].hold();
            holding = true;
            hold_can = now_can;
        }
    }

    //try push can, if sucess set not holding
    void push_can()
    {
        if (canarr[hold_can - 1].push()) holding = false;
    }

}