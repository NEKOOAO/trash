using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalkManager : MonoSingleton<SideWalkManager>
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
    public List<GameObject> all_people;
    private void Start()
    {
        CreatePerson(TrashType.normal, false);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="dir">0 is left 1 is right</param>
    public void CreatePerson(TrashType type, bool dir)
    {
        GameObject new_person;
        Transform entry;
        int walker_speed = 0;
        if (!dir) // left
        {
            entry = left_entry;
            walker_speed = person_speed;

        }
        else // right
        {
            entry = right_entry;
            walker_speed = -person_speed;
        }

        new_person = Instantiate(person, entry.position, Quaternion.identity);
        new_person.GetComponent<Walker>().Walk(walker_speed); //要行人行走
        new_person.GetComponent<PersonDisplay>().person = FindPerson(type);//隨機找一個對應類型玩家
        new_person.GetComponent<PersonDisplay>().Show();
        new_person.GetComponent<PersonDisplay>().SetDir(dir);

        all_people.Add(new_person);
    }

    private Person FindPerson(TrashType type)
    {
        Person person;
        switch (type)
        {
            case TrashType.normal:
                person = normal_person[Random.Range(0, normal_person.Count)];
                return person;
            case TrashType.recycle:
                person = recycle_person[Random.Range(0, recycle_person.Count)];
                return person;
            case TrashType.waste:
                return waste_person[Random.Range(0, waste_person.Count)];
            default:
                return null;

        }
    }

    public void DetectPeople()
    {

    }


}
