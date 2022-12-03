using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mannger : MonoBehaviour
{
    Vector2 pos;
    int now_can = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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

        }
    }

}
