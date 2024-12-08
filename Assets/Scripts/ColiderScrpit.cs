using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColiderScrpit : MonoBehaviour
{

    public List<GameObject> CloseEnemys = new List<GameObject>();
    public Knight_Ai knight_Ai;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Mis")
        {
            if (other.gameObject.tag != this.transform.parent.tag)
            {
                knight_Ai.CloseEnemys2.Add(other.gameObject);
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ai_1" || other.gameObject.tag == "Ai_2" || other.gameObject.tag == "Ai_3" || this.gameObject.tag == "Player")
        {
            knight_Ai.CloseEnemys2.Remove(other.gameObject);
        }
        else if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ai_2" || other.gameObject.tag == "Ai_3" || this.gameObject.tag == "Ai_1")
        {
            knight_Ai.CloseEnemys2.Remove(other.gameObject);
        }
        else if (other.gameObject.tag == "Ai_1" || other.gameObject.tag == "Player" || other.gameObject.tag == "Ai_3" || this.gameObject.tag == "Ai_2")
        {
            knight_Ai.CloseEnemys2.Remove(other.gameObject);
        }
        else if (other.gameObject.tag == "Ai_1" || other.gameObject.tag == "Ai_2" || other.gameObject.tag == "Player" || this.gameObject.tag == "Ai_3")
        {
            knight_Ai.CloseEnemys2.Remove(other.gameObject);
        }
    }
}
