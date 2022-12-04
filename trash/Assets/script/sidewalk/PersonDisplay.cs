using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonDisplay : MonoBehaviour
{
    public Person person;


    private bool direction;

    /// <summary>
    /// 0左1右
    /// </summary>
    public bool Direction
    {
        get { return direction; }
    }

    /// <summary>
    /// 0左1右
    /// </summary>
    /// <param name="dir"></param>
    public void SetDir(bool dir)
    {
        direction = dir;
        
    }

    public void Show()
    {
        this.GetComponent<SpriteRenderer>().sprite = person.sprite;
            
    }
}
