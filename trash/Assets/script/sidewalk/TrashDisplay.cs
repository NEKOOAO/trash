using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDisplay : MonoBehaviour
{
    public Trash trash;

    public void Show()
    {
        this.GetComponent<SpriteRenderer>().sprite = trash.sprite;
    }
}
