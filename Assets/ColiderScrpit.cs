using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderScrpit : MonoBehaviour
{
    void Start()
    {
        li
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Ai_1" ||other.gameObject.tag == "Ai_2" ||other.gameObject.tag == "Ai_3")
        {
            
        }
    }
}
