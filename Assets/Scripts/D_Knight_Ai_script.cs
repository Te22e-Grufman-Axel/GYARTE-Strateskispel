using System.Collections.Generic;
using UnityEngine;

public class D_Knight_Ai : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent Knight;
    UnityEngine.AI.NavMeshPath navMeshPath;

    float timmer;
    [SerializeField] int hp = 100;


    public GameObject Blueflag;

    void Awake()
    {
        navMeshPath = new UnityEngine.AI.NavMeshPath();
        Knight = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Start()
    {
        Blueflag = GameObject.Find("Gyarte_BlueFlag");
    }

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        if (casel_colider_script.Instance.CloseEnemys_P.Count == 0)
        {
            Knight.SetDestination(Blueflag.transform.position);
        }
        else
        {
            if (casel_colider_script.Instance.CloseEnemys_P.Count > 0)
            {
                Knight.SetDestination(casel_colider_script.Instance.CloseEnemys_P[0].transform.position);
            }
            if (casel_colider_script.Instance.CloseEnemys_P.Count > 0 && Vector3.Distance(Knight.transform.position, casel_colider_script.Instance.CloseEnemys_P[0].transform.position) < 10)
            {
                timmer += Time.deltaTime;
                if (timmer > 10)
                {
                    hp -= Random.Range(10, 20);
                    timmer = 0;
                }
            }
        }
    }
}
