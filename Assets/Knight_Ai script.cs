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
        // Debug.Log(Knight.remainingDistance);
      }
    }
    else
    {
      Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
      float RedflagLenght = Knight.remainingDistance;
      // Debug.Log("R: " + RedflagLenght);
      Debug.Log(navMeshPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete);
      // Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
      float GreenFlagLenght = Knight.remainingDistance;
      // Debug.Log("G: " + GreenFlagLenght);
      // Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
      float YellowFlagLenght = Knight.remainingDistance;
      // Debug.Log("Y: " + YellowFlagLenght);

      float closesfort = Math.Min(RedflagLenght, Math.Min(GreenFlagLenght, YellowFlagLenght));

      // Debug.Log(closesfort + "  R: " + RedflagLenght + "  G: " + GreenFlagLenght + "  Y: " + YellowFlagLenght);

      // if (closesfort == RedflagLenght)
      // {
      //   Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
      //   Knight.SetPath(navMeshPath);
      // }
      // else if (closesfort == GreenFlagLenght)
      // {
      //   Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
      //   Knight.SetPath(navMeshPath);
      // }
      // else if (closesfort == YellowFlagLenght)
      // {
      //   Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
      //   Knight.SetPath(navMeshPath);
      // }

    }
  }
}
