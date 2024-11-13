using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casel_colider_script : MonoBehaviour
{
    public D_Knight_Ai D_Knight_Ai;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            D_Knight_Ai.CloseEnemys_P.Add(other.gameObject);
        }
        else if (other.gameObject.tag != "Ai_1")
        {
            D_Knight_Ai.CloseEnemys_Ai1.Add(other.gameObject);
        }
        else if (other.gameObject.tag != "Ai_2")
        {
            D_Knight_Ai.CloseEnemys_Ai2.Add(other.gameObject);
        }
        else if (other.gameObject.tag != "Ai_3")
        {
            D_Knight_Ai.CloseEnemys_Ai3.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            D_Knight_Ai.CloseEnemys_P.Remove(other.gameObject);
        }
        else if (other.gameObject.tag != "Ai_1")
        {
            D_Knight_Ai.CloseEnemys_Ai1.Remove(other.gameObject);
        }
        else if (other.gameObject.tag != "Ai_2")
        {
            D_Knight_Ai.CloseEnemys_Ai2.Remove(other.gameObject);
        }
        else if (other.gameObject.tag != "Ai_3")
        {
             D_Knight_Ai.CloseEnemys_Ai3.Remove(other.gameObject);
        }
    }
}
