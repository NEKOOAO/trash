using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can_mannger : MonoBehaviour
{
    /*-------------------------
        player  -> player
        ishold  -> is held by player
        col_time-> is collide with other can (0 -> NO bigger than 0 -> YES) 
        SR      -> SpriteRenderer use to set layer (player > hold_can > can)
     
    method
        hold    -> player hold this can
        push    -> player try to push this can return sucess or not
     -------------------------*/
    private bool ishold = false;
    public GameObject player;
    private int col_time = 0;
    private Vector2 pos;
    SpriteRenderer SR;

    // init layer = can
    void Start()
    {
        SR = gameObject.GetComponent<SpriteRenderer>();
        SR.sortingLayerName = "can";
    }

    //collide event set col_time and trash
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("can")) col_time++;
        else if (collision.CompareTag("trash"))
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("can")) col_time--;
    }

    void Update(){
        // set pos if hold -> y pos to player head other y pos to floor
        pos = transform.position;
        if (ishold)
        {
            pos = player.transform.position;
            pos.y = -1.19f;
        }
        else pos.y = -2.48f;
        transform.position = pos;
    }

    //set is hold set layer up
    public void hold()
    {
        ishold = true;
        SR.sortingLayerName = "hold_can";
    }
    //if not collide push it and seet layer down , return sucess, other return false 
    public bool push()
    {
        if (col_time == 0)
        {
            ishold = false;
            SR.sortingLayerName = "can";
            return true;
        }
        else return false;
    }
}
