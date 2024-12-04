using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class D_Knight_Ai : MonoBehaviour
{
    // public List<GameObject> casel_colider.CloseEnemys_P = new List<GameObject>();
    public List<GameObject> CloseEnemys_Ai1 = new List<GameObject>();
    public List<GameObject> CloseEnemys_Ai2 = new List<GameObject>();
    public List<GameObject> CloseEnemys_Ai3 = new List<GameObject>();
    UnityEngine.AI.NavMeshAgent Knight;
    UnityEngine.AI.NavMeshPath navMeshPath;
    float timmer;
    [SerializeField]
    int hp = 100;

    public GameObject RedFlag;

    public GameObject GreenFlag;

    public GameObject YellowFlag;

    public GameObject Blueflag;
    public Knight_Ai Knight_Ai;
    Vector3 startspeed;
    public casel_colider_script casel_colider;
    // GameObject casel;



    void Awake()
    {
        navMeshPath = new UnityEngine.AI.NavMeshPath();
        Knight = GetComponent<UnityEngine.AI.NavMeshAgent>();
        casel_colider = GetComponent<casel_colider_script>();
    }

    private void Start()
    {
        // casel = GameObject.Find("Casel_Colider");
        Debug.Log(casel_colider.CloseEnemys_P.Count);
        RedFlag = GameObject.Find("Ai_2/Gyarte_RedFlag");
        GreenFlag = GameObject.Find("Ai_1/Gyarte_GreenFlag");
        YellowFlag = GameObject.Find("Ai_3/Gyarte_YellowFlag");
        Blueflag = GameObject.Find("Gyarte_BlueFlag");
    }


    void Update()
    {
        if (hp <= 0)
        {
            Knight_Ai.CloseEnemys2.Remove(this.gameObject);
            Destroy(gameObject);
        }



        // Debug.Log(casel_colider.CloseEnemys_P.Count + CloseEnemys_Ai1.Count + CloseEnemys_Ai2.Count + CloseEnemys_Ai3.Count);

        if (casel_colider.CloseEnemys_P.Count + CloseEnemys_Ai1.Count + CloseEnemys_Ai2.Count + CloseEnemys_Ai3.Count == 0)
        {
            // Debug.Log("locking for team");
            if (this.gameObject.tag == "Player")
            {
                // Debug.Log("moving to player flag");
                Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }
            else if (this.gameObject.tag == "Ai_1")
            {
                // Debug.Log("moving to ai_1 flag");
                Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }
            else if (this.gameObject.tag == "Ai_2")
            {
                // Debug.Log("moving to ai_2 flag");
                Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }
            else if (this.gameObject.tag == "Ai_3")
            {
                // Debug.Log("moving to ai_3 flag");
                Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }
        }

        else
        {
            if (this.gameObject.tag == "Player" && casel_colider.CloseEnemys_P.Count > 0)
            {
                // Debug.Log(Knight + " " + casel_colider.CloseEnemys_P[0].transform.position);
                Knight.CalculatePath(casel_colider.CloseEnemys_P[0].transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }
            else if (this.gameObject.tag == "Ai_1" && CloseEnemys_Ai1.Count > 0)
            {
                Knight.CalculatePath(CloseEnemys_Ai1[0].transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }
            else if (this.gameObject.tag == "Ai_2" && CloseEnemys_Ai2.Count > 0)
            {
                Knight.CalculatePath(CloseEnemys_Ai2[0].transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }
            else if (this.gameObject.tag == "Ai_3" && CloseEnemys_Ai3.Count > 0)
            {
                Knight.CalculatePath(CloseEnemys_Ai3[0].transform.position, navMeshPath);
                Knight.SetPath(navMeshPath);
            }



            if (casel_colider.CloseEnemys_P.Count > 0 || CloseEnemys_Ai1.Count > 0 || CloseEnemys_Ai2.Count > 0 || CloseEnemys_Ai3.Count > 0)
            {
                if (casel_colider.CloseEnemys_P.Count > 0)
                {
                    if (UnityEngine.Vector3.Distance(Knight.transform.position, casel_colider.CloseEnemys_P[0].transform.position) < 10)
                    {
                        timmer += Time.deltaTime;

                        if (timmer > 10)
                        {
                            hp = hp - UnityEngine.Random.Range(10, 20);
                            timmer = 0;
                        }
                    }
                }
                if (CloseEnemys_Ai1.Count > 0)
                {
                    if (UnityEngine.Vector3.Distance(Knight.transform.position, CloseEnemys_Ai1[0].transform.position) < 10)
                    {
                        timmer += Time.deltaTime;

                        if (timmer > 10)
                        {
                            hp = hp - UnityEngine.Random.Range(10, 20);
                            timmer = 0;
                        }
                    }
                }
                if (CloseEnemys_Ai2.Count > 0)
                {
                    if (UnityEngine.Vector3.Distance(Knight.transform.position, CloseEnemys_Ai2[0].transform.position) < 10)
                    {
                        timmer += Time.deltaTime;

                        if (timmer > 10)
                        {
                            hp = hp - UnityEngine.Random.Range(10, 20);
                            timmer = 0;
                        }
                    }
                }
                if (CloseEnemys_Ai3.Count > 0)
                {
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
}
