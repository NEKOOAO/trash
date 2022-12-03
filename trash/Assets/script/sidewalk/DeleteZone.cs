using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("on collide");
        if (collision.GetComponent<PersonDisplay>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
