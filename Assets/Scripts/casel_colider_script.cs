using System.Collections.Generic;
using UnityEngine;

public class casel_colider_script : MonoBehaviour
{
    public static casel_colider_script Instance { get; private set; }

    public List<GameObject> CloseEnemys_P = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != this.gameObject.tag && other.gameObject.tag != "Player")
        {
            CloseEnemys_P.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != this.gameObject && other.gameObject.tag != "Player")
        {
            if (other.gameObject.tag == "Player")
                CloseEnemys_P.Remove(other.gameObject);
        }
    }
    private void Update()
    {
        for (int i = CloseEnemys_P.Count - 1; i >= 0; i--)
        {
            if (CloseEnemys_P[i] == null)
            {
                CloseEnemys_P.RemoveAt(i);
            }
        }
    }



}
