using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    //public int speed;
    public int throwing_poisition_x;
    public Trash trash;

    private Vector2 move_speed = new Vector2(0, 0);
    private void Start()
    {
        
    }
    public void Walk()
    {
        this.transform.Translate(move_speed);
    }


}
