using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can_mannger : MonoBehaviour
{

    public bool can_push = true;
    public bool ishold = false;
    public GameObject player;
    int col_time = 0;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("can")) col_time++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("can")) col_time--;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        if (ishold)
        {
            pos = player.transform.position;
            pos.y = -1.19f;
        }
        else pos.y = -2.48f;
        transform.position = pos;
    }
    public void hold()
    {
        ishold = true;
    }
    public bool push()
    {
        if (col_time == 0)
        {
            ishold = false;
            return true;
        }
        else return false;
    }
}
