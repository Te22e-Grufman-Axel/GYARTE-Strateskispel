using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
  float closesfort;

  public List<GameObject> CloseEnemys2 = new List<GameObject>();

  private void Awake()
  {
    navMeshPath = new UnityEngine.AI.NavMeshPath();
    Knight = GetComponent<UnityEngine.AI.NavMeshAgent>();
  }


  void Update()
  {
    if (hp < 0) { Destroy(this); }


    if (CloseEnemys2.Count > 0)
    {
      if (Knight.CalculatePath(CloseEnemys2[0].transform.position, navMeshPath) && navMeshPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
      {
        Knight.SetPath(navMeshPath);
      }
    }
    else
    {
      float Reddistance = UnityEngine.Vector3.Distance(Knight.transform.position, RedFlag.transform.position);
      float Greendistance = UnityEngine.Vector3.Distance(Knight.transform.position, GreenFlag.transform.position);
      float Yellowdistance = UnityEngine.Vector3.Distance(Knight.transform.position, YellowFlag.transform.position);
      float bluedistance = UnityEngine.Vector3.Distance(Knight.transform.position, Blueflag.transform.position);


      List<float> closefortList = new List<float> { Reddistance, bluedistance, Greendistance, Yellowdistance };
      closefortList.Sort();


      if (gameObject.tag != "Ai_1" && closefortList[0] == Greendistance)
      {
        Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
      }
      else if (gameObject.tag == "Ai_1" && closefortList[0] == Greendistance)
      {
        closesfort = Math.Min(closefortList[1], Math.Min(closefortList[2], closefortList[3]));
        if (closesfort == Reddistance)
        {
          Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Greendistance)
        {
          Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Yellowdistance)
        {
          Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == bluedistance)
        {
          Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
      }
      else if (gameObject.tag != "Ai_2" && closefortList[0] == Reddistance)
      {
        Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
      }
      else if (gameObject.tag == "Ai_2" && closefortList[0] == Reddistance)
      {
        closesfort = Math.Min(closefortList[1], Math.Min(closefortList[2], closefortList[3]));
        if (closesfort == Reddistance)
        {
          Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Greendistance)
        {
          Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Yellowdistance)
        {
          Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == bluedistance)
        {
          Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
      }
      else if (gameObject.tag != "Ai_3" && closefortList[0] == Yellowdistance)
      {
        Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
      }
      else if (gameObject.tag == "Ai_3" && closefortList[0] == Yellowdistance)
      {
        closesfort = Math.Min(closefortList[1], Math.Min(closefortList[2], closefortList[3]));
        if (closesfort == Reddistance)
        {
          Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Greendistance)
        {
          Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Yellowdistance)
        {
          Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == bluedistance)
        {
          Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
      }
      else if (gameObject.tag != "Player" && closefortList[0] == bluedistance)
      {
        Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
      }
      else if (gameObject.tag == "Player" && closefortList[0] == bluedistance)
      {
        closesfort = Math.Min(closefortList[1], Math.Min(closefortList[2], closefortList[3]));
        if (closesfort == Reddistance)
        {
          Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Greendistance)
        {
          Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Yellowdistance)
        {
          Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == bluedistance)
        {
          Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
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
