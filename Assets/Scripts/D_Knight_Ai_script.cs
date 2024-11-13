using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class D_Knight_Ai : MonoBehaviour
{
    public List<GameObject> CloseEnemys_P = new List<GameObject>();
    public List<GameObject> CloseEnemys_Ai1 = new List<GameObject>();
    public List<GameObject> CloseEnemys_Ai2 = new List<GameObject>();
    public List<GameObject> CloseEnemys_Ai3 = new List<GameObject>();
    UnityEngine.AI.NavMeshAgent Knight;
    UnityEngine.AI.NavMeshPath navMeshPath;
    float timmer;
    int hp = 100;
    [SerializeField]
    GameObject RedFlag;
    [SerializeField]
    GameObject GreenFlag;
    [SerializeField]
    GameObject YellowFlag;
    [SerializeField]
    GameObject Blueflag;


    void Awake()
    {
        navMeshPath = new UnityEngine.AI.NavMeshPath();
        Knight = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (hp < 0) Destroy(this);

        if (this.gameObject.tag == "Player")
        {
            if (Knight.CalculatePath(CloseEnemys_P[0].transform.position, navMeshPath) && navMeshPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
            {
                Knight.SetPath(navMeshPath);
            }
        }
        else if (this.gameObject.tag == "Ai_1")
        {
            if (Knight.CalculatePath(CloseEnemys_Ai1[0].transform.position, navMeshPath) && navMeshPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
            {
                Knight.SetPath(navMeshPath);
            }
        }
        else if (this.gameObject.tag == "Ai_2")
        {
            if (Knight.CalculatePath(CloseEnemys_Ai2[0].transform.position, navMeshPath) && navMeshPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
            {
                Knight.SetPath(navMeshPath);
            }
        }
        else if (this.gameObject.tag == "Ai_3")
        {
            if (Knight.CalculatePath(CloseEnemys_Ai3[0].transform.position, navMeshPath) && navMeshPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
            {
                Knight.SetPath(navMeshPath);
            }
        }


        if (CloseEnemys_P.Count + CloseEnemys_Ai1.Count + CloseEnemys_Ai2.Count + CloseEnemys_Ai3.Count == 0)
        {
            if (this.gameObject.tag == "player")
            {
                Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }
            else if (this.gameObject.tag == "Ai_1")
            {
                Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }
            else if (this.gameObject.tag == "Ai_2")
            {
                Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }
            else if (this.gameObject.tag == "Ai_3")
            {
                Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }
        }

        else
        {
            if (CloseEnemys_P.Count > 0 || CloseEnemys_Ai1.Count > 0 || CloseEnemys_Ai2.Count > 0 || CloseEnemys_Ai3.Count > 0)
            {
                if (UnityEngine.Vector3.Distance(Knight.transform.position, CloseEnemys_P[0].transform.position) < 10)
                {
                    timmer += Time.deltaTime;

                    if (timmer > 10)
                    {
                        hp = hp - UnityEngine.Random.Range(10, 20);
                        timmer = 0;
                    }
                }
                if (UnityEngine.Vector3.Distance(Knight.transform.position, CloseEnemys_Ai1[0].transform.position) < 10)
                {
                    timmer += Time.deltaTime;

                    if (timmer > 10)
                    {
                        hp = hp - UnityEngine.Random.Range(10, 20);
                        timmer = 0;
                    }
                }
                if (UnityEngine.Vector3.Distance(Knight.transform.position, CloseEnemys_Ai2[0].transform.position) < 10)
                {
                    timmer += Time.deltaTime;

                    if (timmer > 10)
                    {
                        hp = hp - UnityEngine.Random.Range(10, 20);
                        timmer = 0;
                    }
                }
                if (UnityEngine.Vector3.Distance(Knight.transform.position, CloseEnemys_Ai3[0].transform.position) < 10)
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
