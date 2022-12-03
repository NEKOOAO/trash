using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{

    public void Walk(int speed)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    public void Stop()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    public void Throw(GameObject trash, Vector2 velocity,Trash trash_data)
    {
        GameObject new_trash = Instantiate(trash, this.transform.position, Quaternion.identity);
        new_trash.GetComponent<TrashDisplay>().trash = trash_data;
        new_trash.GetComponent<TrashDisplay>().Show();
        new_trash.GetComponent<Rigidbody2D>().velocity = velocity;

    }
}
