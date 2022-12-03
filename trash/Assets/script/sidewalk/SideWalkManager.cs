using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalkManager : MonoBehaviour
{
    //entry
    public Transform left_entry;
    public Transform right_entry;
    //prefab
    public GameObject person;
    public GameObject trash;
    //SO
    public List<Person> normal_person;
    public List<Person> recycle_person;
    public List<Person> waste_person;
    public List<Trash> normal_trash;
    public List<Trash> recycle_trash;
    public List<Trash> waste_trash;
    //parameter
    public int person_speed; //行人移動速度
    public int total_person; //總人數
    // store
    private List<GameObject> all_people;
    private void Start()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="entry">0 is left 1 is right</param>
    public void CreatePerson(TrashType type, bool entry)
    {
        GameObject new_person;
        if (!entry)
        {
            new_person = Instantiate(person, left_entry,false);
            new_person.GetComponent<Rigidbody2D>().velocity = new Vector2(person_speed, 0);
        }
        else
        {
            new_person = Instantiate(person, right_entry,false);
            new_person.GetComponent<Rigidbody2D>().velocity = new Vector2(-person_speed, 0);
        }
//        new_person.GetComponent<PersonDisplay>().person = FindPerson(type);//隨機找一個對應類型玩家
//        new_person.GetComponent<PersonDisplay>().Show();
        all_people.Add(new_person);
    }

    private Person FindPerson(TrashType type)
    {
        switch (type)
        {
            case TrashType.normal:
                return normal_person[Random.Range(0, normal_person.Count)];
            case TrashType.recycle:
                return recycle_person[Random.Range(0, recycle_person.Count)];
            case TrashType.waste:
                return waste_person[Random.Range(0, waste_person.Count)];
            default:
                return null;

        }
    }


}
