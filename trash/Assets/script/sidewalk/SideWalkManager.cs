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
        Debug.LogFormat("w:{0},h:{1}", Screen.width, Screen.height);
    }
    /// <summary>
    /// 創建行人,傳入參數:type,dir,throw_position(V2)
    /// </summary>
    /// <param name="type"></param>
    /// <param name="dir">0 is left 1 is right</param>
    //創造人並給對應的trash type與左方右方
    public void CreatePerson(TrashType type, bool dir,Vector2 throw_position)
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
        new_person.GetComponent<Walker>().throw_position = throw_position; //告訴行人丟東西地點
        new_person.GetComponent<Walker>().Walk(walker_speed); //要行人行走
        new_person.GetComponent<PersonDisplay>().person = FindRandomPerson(type);//隨機找一個對應類型玩家
        new_person.GetComponent<PersonDisplay>().Show();
        new_person.GetComponent<PersonDisplay>().SetDir(dir);

        all_people.Add(new_person);
    }
    
    private Person FindRandomPerson(TrashType type)
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

    public void DeletePerson(GameObject person)
    {
        Destroy(person);
        all_people.Remove(person);
    }
//偵測行人是否要丟垃圾，如果要丟就執行
//每個update都跑一次即可
    public void DetectThrow()
    {
        foreach (GameObject item in all_people)
        {
            if(! item.GetComponent<Walker>().IsThrow){
                continue;
            }
            float x_poisiotn = item.transform.position.x;
            bool dir = item.GetComponent<PersonDisplay>().Direction;
            float throw_position = item.GetComponent<Walker>().throw_position.x;
            TrashType type = item.GetComponent<PersonDisplay>().person.type;
            //
            Vector2 test = Vector2.zero;
            if (!dir && throw_position>=x_poisiotn)
            {
                item.GetComponent<Walker>().Throw(trash, Vector2.zero, FindRandomTrash(type));
            }
            else if (dir && throw_position <= x_poisiotn)
            {
                item.GetComponent<Walker>().Throw(trash, Vector2.zero, FindRandomTrash(type));
            }
        }
    }

    private Trash FindRandomTrash(TrashType type)
    {
        Trash trash;
        switch (type)
        {
            case TrashType.normal:
                trash = normal_trash[Random.Range(0, normal_trash.Count)];
                break;
            case TrashType.recycle:
                trash = recycle_trash[Random.Range(0, recycle_trash.Count)];
                break;
            case TrashType.waste:
                trash = waste_trash[Random.Range(0, waste_trash.Count)];
                break;
            default:
                return null;

        }
        return trash;
    }
}
