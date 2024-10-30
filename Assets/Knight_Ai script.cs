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

  public List<GameObject> CloseEnemys2 = new List<GameObject>();

  private void Awake()
  {
    navMeshPath = new UnityEngine.AI.NavMeshPath();
    Knight = GetComponent<UnityEngine.AI.NavMeshAgent>();
  }


  void Update()
  {
    if (CloseEnemys2.Count > 0)
    {
      if (Knight.CalculatePath(CloseEnemys2[0].transform.position, navMeshPath) && navMeshPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
      {
        Knight.SetPath(navMeshPath);
        // Debug.Log(Knight.remainingDistance);
      }
    }
    else
    {
      float Reddistance = UnityEngine.Vector3.Distance(Knight.transform.position, RedFlag.transform.position);
      float Greendistance = UnityEngine.Vector3.Distance(Knight.transform.position, GreenFlag.transform.position);
      float Yellowdistance = UnityEngine.Vector3.Distance(Knight.transform.position, YellowFlag.transform.position);
  
      float closesfort = Math.Min(Reddistance, Math.Min(Greendistance, Yellowdistance));
Debug.Log("closesfort " + closesfort + " R " + Reddistance + " G " + Greendistance + " Y " + Yellowdistance);
      if (closesfort == Reddistance)
      {
        Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
        Debug.Log("Red");
      }
      else if (closesfort == Greendistance)
      {
        Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
        Debug.Log("green");
      }
      else if (closesfort == Yellowdistance)
      {
        Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
        Debug.Log("yellow");
      }








    }
  }
}
