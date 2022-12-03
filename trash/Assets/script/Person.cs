using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPerson",menuName = "CreateSO/Create Person")]
public class Person : ScriptableObject
{
    public TrashType type;
    public string person_name;
    public Sprite sprite;

}
