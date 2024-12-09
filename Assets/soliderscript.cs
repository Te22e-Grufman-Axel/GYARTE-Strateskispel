using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soliderscript : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public Material material3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Renderer rend = gameObject.GetComponent<Renderer>();
        rend = gameObject.GetComponentInChildren<Renderer>();

        if (gameObject.transform.parent.tag == "Ai_1")
        {
            rend.sharedMaterial = material1;
        }
        else if (gameObject.transform.parent.tag == "Ai_2")
        {
            rend.sharedMaterial = material2;
        }
        else if (gameObject.transform.parent.tag == "Ai_3")
        {
            rend.sharedMaterial = material3;
        }
    }
}
