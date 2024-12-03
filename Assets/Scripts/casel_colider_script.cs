using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casel_colider_script : MonoBehaviour
{
    public D_Knight_Ai D_Knight_Ai;
    public List<GameObject> CloseEnemys_P = new List<GameObject>();
    public List<GameObject> CloseEnemys_Ai1 = new List<GameObject>();
    public List<GameObject> CloseEnemys_Ai2 = new List<GameObject>();
    public List<GameObject> CloseEnemys_Ai3 = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != this.gameObject && other.gameObject.tag != this.gameObject.tag && other.gameObject.tag != "Mis")
        {
            // Debug.Log("Någon är nära");
            if (other.gameObject.tag != "Player")
            {
                CloseEnemys_P.Add(other.gameObject);
            }
            else if (other.gameObject.tag != "Ai_1")
            {
                CloseEnemys_Ai1.Add(other.gameObject);
            }
            else if (other.gameObject.tag != "Ai_2")
            {
                CloseEnemys_Ai2.Add(other.gameObject);
            }
            else if (other.gameObject.tag != "Ai_3")
            {
                CloseEnemys_Ai3.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != this.gameObject && other.gameObject.tag != this.gameObject.tag)
        {
            if (other.gameObject.tag != "Player")
            {
                CloseEnemys_P.Remove(other.gameObject);
            }
            else if (other.gameObject.tag != "Ai_1")
            {
                CloseEnemys_Ai1.Remove(other.gameObject);
            }
            else if (other.gameObject.tag != "Ai_2")
            {
                CloseEnemys_Ai2.Remove(other.gameObject);
            }
            else if (other.gameObject.tag != "Ai_3")
            {
                CloseEnemys_Ai3.Remove(other.gameObject);
            }
        }
    }

}