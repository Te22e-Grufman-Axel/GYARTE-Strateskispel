using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderScrpit : MonoBehaviour
{
    
    public  List<GameObject> CloseEnemys = new List<GameObject>();
    void Start()
    {

    }

    void Update()
    {
    // if (CloseEnemys.Count > 0)
    // {
    //   Debug.Log(CloseEnemys);
    // }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ai_1" || other.gameObject.tag == "Ai_2" || other.gameObject.tag == "Ai_3")
        {
          
            CloseEnemys.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ai_1" || other.gameObject.tag == "Ai_2" || other.gameObject.tag == "Ai_3")
        {
            CloseEnemys.Remove(other.gameObject);
        }
    }
}
