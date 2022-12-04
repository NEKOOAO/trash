using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("trash"))
        {
            //trash on ground
            handler.Instance.MinusScore();
            Debug.Log("trash on ground");
            Destroy(collision.gameObject);
        }
    }
}
