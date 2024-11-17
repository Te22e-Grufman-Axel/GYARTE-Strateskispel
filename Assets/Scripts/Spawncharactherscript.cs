using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawncharactherscript : MonoBehaviour
{
    public GameObject Attacker;
    public GameObject Defenender;

    public Transform parent;
    public string Tag;

    public void Spawnattacker()
    {
        GameObject newObject = Instantiate(Attacker, parent);
        newObject.tag = tag;
    }
    public void spawndefender()
    {
        GameObject newObject = Instantiate(Defenender, parent);
        newObject.tag = tag;
    }
}
