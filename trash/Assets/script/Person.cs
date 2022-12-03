using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPerson",menuName = "CreateSO/Create Person")]
public class Person : ScriptableObject
{
    public TrashType type;
    public string person_name;
    public Sprite sprite;
    /// <summary>
    /// 0左1右
    /// </summary>
    private bool direction;
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

}
