using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knight_Ai : MonoBehaviour
{
  UnityEngine.AI.NavMeshAgent Knight;
  UnityEngine.AI.NavMeshPath navMeshPath;

  [SerializeField]
  GameObject Ai_1_knight;
  GameObject Colider;
  public List<GameObject> CloseEnemys2 = new List<GameObject>();
  // Start is called before the first frame update
  private void Awake()
  {
    Colider = GameObject.Find("Colider");
    navMeshPath = new UnityEngine.AI.NavMeshPath();
    Knight = GetComponent<UnityEngine.AI.NavMeshAgent>();
  }


  // Update is called once per frame
  void Update()
  {
    CloseEnemys2.AddRange(Colider.GetComponent<ColiderScrpit>().CloseEnemys);

    if(CloseEnemys2.Count > 0);





    if (Knight.CalculatePath(Ai_1_knight.transform.position, navMeshPath) && navMeshPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
    {
      //move to target
      Knight.SetPath(navMeshPath);
    }
  }
}
