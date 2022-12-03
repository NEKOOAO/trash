using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mannger : MonoBehaviour
{
    Vector2 pos;
    int now_can = 0;
    public bool incan1, incan2, incan3, holding = false;
    public can_mannger[] canarr=new can_mannger[3];
    // Start is called before the first frame update
    void Start()
    {
        incan1 = false;
        incan2 = false;
        incan3 = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) { 
        if (collision.gameObject.name == "trash_can1") incan1 = true;
        if (collision.gameObject.name == "trash_can2") incan2 = true;
        if (collision.gameObject.name == "trash_can3") incan3 = true;
        Debug.Log(collision.gameObject.name);
        Debug.Log("coll");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "trash_can1") incan1 = false;
        if (collision.gameObject.name == "trash_can2") incan2 = false;
        if (collision.gameObject.name == "trash_can3") incan3 = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (incan1) now_can = 1;
        else if (incan2) now_can = 2;
        else if (incan3) now_can = 3;
        else now_can = 0;
        pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(pos.x-10*Time.deltaTime,pos.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position = new Vector2(pos.x + 10 * Time.deltaTime, pos.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (holding) { }
            else take_up_can();
        }
    }
    void take_up_can()
    {
        if (now_can != 0)
        {
            canarr[now_can-1].hold();
            holding = true;
        }
    }
}
