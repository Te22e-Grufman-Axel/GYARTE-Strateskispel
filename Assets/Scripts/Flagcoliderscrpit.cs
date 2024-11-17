using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Flagcoliderscrpit : MonoBehaviour
{
    float Timmer;
    [SerializeField]
    int Hp = 100;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != transform.parent.gameObject.tag)
        {
            Timmer += 1 * Time.deltaTime;
            if (Timmer > 1)
            {
                Hp = Hp - 5;
                Timmer = 0;
                if (Hp < 0)
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }
}
