using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Flagcoliderscrpit : MonoBehaviour
{
    public float Timmer;
    [SerializeField]
    int Hp = 100;


    private void OnTriggerStay(Collider other)
    {
        if (this.gameObject.tag == "Ai_3") Debug.Log(transform.parent.gameObject.tag + "  :  Steg 1");
        // Debug.Log(othesr.tag);
        // Debug.Log(transform.parent.gameObject.tag);
        // Debug.Log(transform.parent.gameObject.tag + " : " + Hp);
        if (other.gameObject.tag != "Mis")
        {
            if (this.gameObject.tag == "Ai_3") Debug.Log(transform.parent.gameObject.tag + "  :  Steg 2");
            if (other.gameObject.tag != transform.parent.gameObject.tag)
            {
                if (this.gameObject.tag == "Ai_3") Debug.Log(transform.parent.gameObject.tag + "  :  Steg 3");
                Timmer += 1 * Time.deltaTime;
                if (Timmer > 1)
                {
                    if (this.gameObject.tag == "Ai_3") Debug.Log(transform.parent.gameObject.tag + "  :  Steg 4");
                    Hp = Hp - 5;
                    Timmer = 0;
                    if (Hp < 0)
                    {
                        if (this.gameObject.tag == "Ai_3") Debug.Log(transform.parent.gameObject.tag + "  :  Steg 5");
                        Destroy(transform.parent.gameObject);
                    }
                }
            }
        }
    }
}
