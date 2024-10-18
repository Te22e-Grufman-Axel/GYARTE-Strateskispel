using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        float lengt = Knight.remainingDistance;
      }
    }
    else
    {
      Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
      float RedflagLenght = Knight.remainingDistance;
      Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
      float GreenFlagLenght = Knight.remainingDistance;
      Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
      float YellowFlagLenght = Knight.remainingDistance;

     float closesfort = Math.Min(RedflagLenght, Math.Min(GreenFlagLenght, YellowFlagLenght));
      

    }
  }
}
