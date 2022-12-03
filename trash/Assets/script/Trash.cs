using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum TrashType
{
    normal,recycle,waste
}
[CreateAssetMenu(fileName = "New Trash",menuName = "CreateSO/Create Trash")]
public class Trash : ScriptableObject
{
    public TrashType type;
    public string trash_name;
    public Sprite sprite;


}
