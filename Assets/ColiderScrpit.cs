using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColiderScrpit : MonoBehaviour
{

    public List<GameObject> CloseEnemys = new List<GameObject>();
    public Knight_Ai knight_Ai;
    void Start()
    {

    }

    void Update()
    {
        if (CloseEnemys.Count > 0)
        {
        //   Debug.Log(CloseEnemys);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ai_1" || other.gameObject.tag == "Ai_2" || other.gameObject.tag == "Ai_3")
        {
            knight_Ai.CloseEnemys2.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Ai_1" || other.gameObject.tag == "Ai_2" || other.gameObject.tag == "Ai_3")
        {
            knight_Ai.CloseEnemys2.Remove(other.gameObject);
        }
    }
}
