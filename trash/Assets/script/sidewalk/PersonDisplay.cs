using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonDisplay : MonoBehaviour
{
    public Person person;

    public void Show()
    {
        this.GetComponent<SpriteRenderer>().sprite = person.sprite;
            
    }
}
