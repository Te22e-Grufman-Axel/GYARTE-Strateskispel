using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Flagcoliderscrpit : MonoBehaviour
{
    float Timmer;
    int Hp = 100;
    public string Tag;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != Tag)
        {
            Timmer += 1 * Time.deltaTime;
            if (Timmer > 1)
            {
                Hp = Hp - 1;
                Timmer = 0;
                if (Hp < 0)
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }
}
