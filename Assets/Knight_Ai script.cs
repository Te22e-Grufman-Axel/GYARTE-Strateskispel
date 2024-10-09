using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Ai : MonoBehaviour
{
  UnityEngine.AI.NavMeshAgent Knight;
  UnityEngine.AI.NavMeshPath navMeshPath;

  [SerializeField]
  GameObject Ai_1_knight;
  // Start is called before the first frame update
  private void Awake()
  {
    navMeshPath = new UnityEngine.AI.NavMeshPath();
    Knight = GetComponent<UnityEngine.AI.NavMeshAgent>();
  }


  // Update is called once per frame
  void Update()
  {
    if (Knight.CalculatePath(Ai_1_knight.transform.position, navMeshPath) && navMeshPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
    {
      //move to target
      Knight.SetPath(navMeshPath);
    }
  }
}
