using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Knight_Ai : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent Knight;
    UnityEngine.AI.NavMeshPath navMeshPath;
    public List<GameObject> CloseEnemys2 = new List<GameObject>();
    float timmer;
    int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        navMeshPath = new UnityEngine.AI.NavMeshPath();
        Knight = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0) { Destroy(this); }



        if (CloseEnemys2.Count > 0)
        {
            for (int i = 0; i < CloseEnemys2.Count; i++)
            {
                if (UnityEngine.Vector3.Distance(Knight.transform.position, CloseEnemys2[i].transform.position) < 10)
                {
                    timmer += Time.deltaTime;

                    if (timmer > 10)
                    {
                        hp = hp - UnityEngine.Random.Range(10, 20);
                        timmer = 0;
                    }
                }
            }
        }
    }
}
