using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can_mannger : MonoBehaviour
{

    public bool can_push = true;
    public bool ishold = false;
    public GameObject player;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        
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
    public void push()
    {
        ishold = false;
    }
}
