using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Knight_Ai : MonoBehaviour
{
  UnityEngine.AI.NavMeshAgent Knight;
  UnityEngine.AI.NavMeshPath navMeshPath;
  [SerializeField]
  GameObject RedFlag;
  [SerializeField]
  GameObject GreenFlag;
  [SerializeField]
  GameObject YellowFlag;
  [SerializeField]
  GameObject Blueflag;
  [SerializeField]
  float timmer;
  [SerializeField]
  int hp = 100;

  public List<GameObject> CloseEnemys2 = new List<GameObject>();

  private void Awake()
  {
    navMeshPath = new UnityEngine.AI.NavMeshPath();
    Knight = GetComponent<UnityEngine.AI.NavMeshAgent>();
  }


  void Update()
  {
    if (hp < 0) { Destroy(this); }
    Debug.Log("Workings");


    if (CloseEnemys2.Count > 0)
    {
      if (Knight.CalculatePath(CloseEnemys2[0].transform.position, navMeshPath) && navMeshPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
      {
        Knight.SetPath(navMeshPath);
      }
      Debug.Log("Going for enemy");
    }
    else
    {
      float Reddistance = UnityEngine.Vector3.Distance(Knight.transform.position, RedFlag.transform.position);
      float Greendistance = UnityEngine.Vector3.Distance(Knight.transform.position, GreenFlag.transform.position);
      float Yellowdistance = UnityEngine.Vector3.Distance(Knight.transform.position, YellowFlag.transform.position);
      float bluedistance = UnityEngine.Vector3.Distance(Knight.transform.position, Blueflag.transform.position);
              Debug.Log("findign casel");

      float closesfort = Math.Min(Math.Min(Reddistance, bluedistance), Math.Min(Greendistance, Yellowdistance));
              Debug.Log(closesfort);


      /*
        Lista av alla flaggors positioj
        en int fr index
        en float fr distance

        loopa igenom alla flaggor kolla om dist är mindre en distance varablen
        om den är det sätt i till loopens index

      */

      if (closesfort == Reddistance && gameObject.tag != "Ai_2")
      {
        Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
        Debug.Log("Red");
      }
      else if (closesfort == Greendistance && gameObject.tag != "Ai_1")
      {
        Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
        Debug.Log("green");
      }
      else if (closesfort == Yellowdistance && gameObject.tag != "Ai_3")
      {
        Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
        Debug.Log("yellow");
      }
      else if (closesfort == bluedistance && gameObject.tag != "Player")
      {
        Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
        Debug.Log("Blue");
      }
    }



    if (CloseEnemys2.Count > 0)
    {
      for (int i = 0; i < CloseEnemys2.Count; i++)
      {
        if (UnityEngine.Vector3.Distance(Knight.transform.position, CloseEnemys2[i].transform.position) < 10)
        {
          timmer += Time.deltaTime;

          if (timmer > 5)
          {
            hp = hp - UnityEngine.Random.Range(10, 20);
            timmer = 0;
          }
        }
      }
    }
  }
}
