using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public bool IsThrow = true;
    public Vector2 throw_position = Vector2.zero;

    private void Start() {
        IsThrow = true;
    }
    public void Walk(int speed)
    {
        this.GetComponent<Rigidbody2D>().velocity = speed * Vector2.right;
    }

    public void Stop()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }

    public void Throw(GameObject trash, Vector2 velocity,Trash trash_data)
    {
        Stop();
        GameObject new_trash = Instantiate(trash, this.transform.position, Quaternion.identity);
        new_trash.GetComponent<TrashDisplay>().trash = trash_data;
        new_trash.GetComponent<TrashDisplay>().Show();
        new_trash.GetComponent<Rigidbody2D>().velocity = velocity;
        IsThrow = false;

    }
}
