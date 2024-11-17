using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawncharactherscript : MonoBehaviour
{
    public GameObject Attacker;
    public GameObject Defenender;
    public GameObject Spawnlocation;

    public Transform parent;
    public string Tag = "Player";
    public Vector3 Goodname;
    public Vector3 SpawnRoation;
    public GoldScript gold;
    private void Start()
    {
        Goodname.Set(802, 40, 758);
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
        }
    }
    public void spawndefender()
    {
        if (gold.gold >= 5)
        {
            gold.gold = gold.gold - 5;
            SpawnRoation.Set(0, 90, 0);
            Quaternion rotation = Quaternion.Euler(SpawnRoation);
            GameObject newObject = Instantiate(Defenender, parent);
            newObject.tag = Tag;
            newObject.transform.position = Goodname;
        }
    }


}
