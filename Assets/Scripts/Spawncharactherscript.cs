using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawncharactherscript : MonoBehaviour
{
    public GameObject Attacker;
    public GameObject Defenender;
    public GameObject Spawnlocation;
    GameObject NewObjectCild;

    public Transform parent;
    public string Tag = "Player";
    Vector3 Goodname;
    Vector3 SpawnRoation;
    public GoldScript gold;
    private void Start()
    {
        Goodname.Set(802, 51, 758);
    }

    public void Spawnattacker()
    {
        if (gold.gold >= 5)
        {
            gold.gold = gold.gold - 5;
            SpawnRoation.Set(0, 90, 0);
            Quaternion rotation = Quaternion.Euler(SpawnRoation);
            GameObject newObject = Instantiate(Attacker, Goodname, rotation, parent);
            newObject.tag = Tag;
            newObject.transform.position = Goodname;
            Transform childTransform = newObject.transform.Find("Colider");
            childTransform.gameObject.tag = "Player";

        }
    }
    public void spawndefender()
    {
        if (gold.gold >= 5)
        {
            gold.gold = gold.gold - 5;
            SpawnRoation.Set(0, 90, 0);
            Quaternion rotation = Quaternion.Euler(SpawnRoation);
            GameObject newObject = Instantiate(Defenender, Goodname, rotation, parent);
            newObject.tag = Tag;
            newObject.transform.position = Goodname;

            // Time.timeScale = 0;
        }
    }


}
