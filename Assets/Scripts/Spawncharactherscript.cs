using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawncharactherscript : MonoBehaviour
{
    public GameObject Attacker;
    public GameObject Defenender;
    public GameObject Spawnlocation;
    public int NumberofAttackers = 0;
    public int NumberOfDefenders = 0;
    GameObject NewObjectCild;
    public GameObject D_knigt_Ai;

    public Transform parent;
    public string Tag = "Player";
    Vector3 Goodname;
    Vector3 SpawnRoation;
    public GoldScript gold;
    public casel_colider_script closeenemys_p2;
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
            childTransform.gameObject.tag = "Mis";
            NumberofAttackers++;
            Knight_Ai knightAI = newObject.GetComponent<Knight_Ai>();
            knightAI.D_Knight_Ai = D_knigt_Ai.GetComponent<D_Knight_Ai>();
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
            NumberOfDefenders++;
            Knight_Ai knightAI = newObject.GetComponent<Knight_Ai>();
            knightAI.D_Knight_Ai = D_knigt_Ai.GetComponent<D_Knight_Ai>();
            
        }
    }


}
