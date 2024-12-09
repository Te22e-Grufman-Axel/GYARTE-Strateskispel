using System;
using System.Collections;
using System.Collections.Generic;
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
  float timmer2;
  [SerializeField]
  int hp = 110;
  float closesfort;
  float Reddistance = 1000;
  float Greendistance = 1000;
  float bluedistance = 1000;
  float Yellowdistance = 1000;
  Vector3 LockRoation;
  public D_Knight_Ai D_Knight_Ai;
  Vector3 startspeed;

  public List<GameObject> CloseEnemys2;
  public casel_colider_script casel_colider;
  public List<float> closefortList = new List<float>();


  private void Awake()
  {
    navMeshPath = new UnityEngine.AI.NavMeshPath();
    Knight = GetComponent<UnityEngine.AI.NavMeshAgent>();
  }
  private void Start()
  {
    startspeed.Set(0, 0, 0);
    Knight.velocity = startspeed;
    LockRoation.Set(0, Knight.transform.rotation.y, 0);
    Quaternion rotation = Quaternion.Euler(LockRoation);
    Knight.transform.rotation = rotation;
    CloseEnemys2.Clear();

    RedFlag = GameObject.Find("Ai_2/Gyarte_RedFlag");
    GreenFlag = GameObject.Find("Ai_1/Gyarte_GreenFlag");
    YellowFlag = GameObject.Find("Ai_3/Gyarte_YellowFlag");
    Blueflag = GameObject.Find("Gyarte_BlueFlag");

  }

  void Update()
  {
    timmer2 = timmer2 + Time.deltaTime;

    if (timmer2 > 1)
    {
      timmer2 = 0;
      Knight.CalculatePath(startspeed, navMeshPath);
      Knight.SetPath(navMeshPath);
    }

    Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
    Knight.SetPath(navMeshPath);
    for (int i = CloseEnemys2.Count - 1; i >= 0; i--)
    {
      if (this.gameObject != null && CloseEnemys2[i] != null)
      {
        if (CloseEnemys2[i].tag == gameObject.tag)
        {
          CloseEnemys2.RemoveAt(i);
        }
        if (CloseEnemys2[i].gameObject == null)
        {
          CloseEnemys2.RemoveAt(i);
        }
      }
    }
    if (hp <= 10)
    {
      Destroy(gameObject);
      if (casel_colider.CloseEnemys_P.Contains(gameObject))
      {
        casel_colider.CloseEnemys_P.Remove(this.gameObject);
      }
      foreach (GameObject obj in CloseEnemys2)
      {
        if (obj != null && obj.transform.GetComponent<Knight_Ai>() != null)
        {
          obj.transform.GetComponent<Knight_Ai>().remove(gameObject);
        }
      }

      Collider[] colliders = Physics.OverlapSphere(transform.position, 50f);
      foreach (Collider collider in colliders)
      {
        ColiderScrpit coliderScript = collider.GetComponent<ColiderScrpit>();
        if (coliderScript != null && coliderScript.knight_Ai != null)
        {
          coliderScript.knight_Ai.CloseEnemys2.Remove(this.gameObject);
        }
      }



    }

    if (CloseEnemys2.Count > 0)
    {
      if (Knight.CalculatePath(CloseEnemys2[0].transform.position, navMeshPath) && navMeshPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
      {
        Knight.SetPath(navMeshPath);
      }
    }
    else
    {
      if (RedFlag != null) { Reddistance = UnityEngine.Vector3.Distance(Knight.transform.position, RedFlag.transform.position); }
      if (GreenFlag != null) { Greendistance = UnityEngine.Vector3.Distance(Knight.transform.position, GreenFlag.transform.position); }
      if (YellowFlag != null) { Yellowdistance = UnityEngine.Vector3.Distance(Knight.transform.position, YellowFlag.transform.position); }
      if (Blueflag != null) { bluedistance = UnityEngine.Vector3.Distance(Knight.transform.position, Blueflag.transform.position); }

      closefortList.Clear();
      closefortList.Add(Reddistance);
      closefortList.Add(bluedistance);
      closefortList.Add(Greendistance);
      closefortList.Add(Yellowdistance);
      // if (RedFlag == null) { closefortList.Remove(Reddistance); }
      // if (GreenFlag == null) { closefortList.Remove(Greendistance); }
      // if (YellowFlag == null) { closefortList.Remove(Yellowdistance); }
      // if (Blueflag == null) { closefortList.Remove(bluedistance); }
      if (RedFlag == null) { Reddistance *= 1000; }
      if (GreenFlag == null) { Greendistance *= 1000; }
      if (YellowFlag == null) { Yellowdistance *= 1000; }
      if (Blueflag == null) { bluedistance *= 1000; }
      closefortList.Sort();

      if (gameObject.tag != "Ai_1" && closefortList[0] == Greendistance && GreenFlag != null)
      {
        // Debug.Log(gameObject.tag + "1");
        Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
      }
      else if (gameObject.tag == "Ai_1" && closefortList[0] == Greendistance)
      {
        closesfort = Math.Min(closefortList[1], Math.Min(closefortList[2], closefortList[3]));
        if (closesfort == Reddistance && RedFlag != null)
        {
          // Debug.Log(gameObject.tag + "2");
          Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Greendistance && GreenFlag != null)
        {
          // Debug.Log(gameObject.tag + "3");
          Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Yellowdistance && YellowFlag != null)
        {
          // Debug.Log(gameObject.tag + "4");
          Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == bluedistance && Blueflag != null && gameObject.tag != "Player")
        {
          // Debug.Log(gameObject.tag + "5");
          Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
      }
      else if (gameObject.tag != "Ai_2" && closefortList[0] == Reddistance && RedFlag != null)
      {
        // Debug.Log(gameObject.tag + "6");
        Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
      }
      else if (gameObject.tag == "Ai_2" && closefortList[0] == Reddistance)
      {
        closesfort = Math.Min(closefortList[1], Math.Min(closefortList[2], closefortList[3]));
        if (closesfort == Reddistance && RedFlag != null)
        {
          // Debug.Log(gameObject.tag + "7");
          Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Greendistance && GreenFlag != null)
        {
          // Debug.Log(gameObject.tag + "8");
          Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Yellowdistance && YellowFlag != null)
        {
          // Debug.Log(gameObject.tag + "9");
          Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == bluedistance && Blueflag != null && gameObject.tag != "Player")
        {
          // Debug.Log(gameObject.tag + "10");
          Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
      }
      else if (gameObject.tag != "Ai_3" && closefortList[0] == Yellowdistance && YellowFlag != null)
      {
        // Debug.Log(gameObject.tag + "11");
        Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
      }
      else if (gameObject.tag == "Ai_3" && closefortList[0] == Yellowdistance)
      {
        closesfort = Math.Min(closefortList[1], Math.Min(closefortList[2], closefortList[3]));
        if (closesfort == Reddistance && RedFlag != null)
        {
          // Debug.Log(gameObject.tag + "12");
          Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Greendistance && GreenFlag != null)
        {
          // Debug.Log(gameObject.tag + "13");
          Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Yellowdistance && YellowFlag != null)
        {
          // Debug.Log(gameObject.tag + "14");
          Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == bluedistance && Blueflag != null && gameObject.tag != "Player")
        {
          // Debug.Log(gameObject.tag + "15");
          Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
      }
      else if (gameObject.tag != "Player" && closefortList[0] == bluedistance && Blueflag != null)
      {
        // Debug.Log(gameObject.tag + "16");
        Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
        Knight.SetPath(navMeshPath);
      }
      else if (gameObject.tag == "Player" && closefortList[0] == bluedistance)
      {
        closesfort = Math.Min(closefortList[1], Math.Min(closefortList[2], closefortList[3]));
        if (closesfort == Reddistance && RedFlag != null)
        {
          // Debug.Log(gameObject.tag + "17");
          Knight.CalculatePath(RedFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Greendistance && GreenFlag != null)
        {
          // Debug.Log(gameObject.tag + "18");
          Knight.CalculatePath(GreenFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == Yellowdistance && YellowFlag != null)
        {
          // Debug.Log(gameObject.tag + "19");
          Knight.CalculatePath(YellowFlag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
        else if (closesfort == bluedistance && Blueflag != null && gameObject.tag != "Player")
        {
          // Debug.Log(gameObject.tag + "20");
          Knight.CalculatePath(Blueflag.transform.position, navMeshPath);
          Knight.SetPath(navMeshPath);
        }
      }
    }

    if (CloseEnemys2.Count > 0)
    {
      for (int i = 0; i < CloseEnemys2.Count; i++)
      {
        if (Vector3.Distance(Knight.transform.position, CloseEnemys2[i].transform.position) < 10)
        {
          timmer += Time.deltaTime;

          if (timmer > 5)
          {
            hp -= UnityEngine.Random.Range(10, 20);
            timmer = 0;
          }
        }
      }
    }
  }

  public void remove(GameObject remove)
  {
    CloseEnemys2.Remove(remove);
  }
}
