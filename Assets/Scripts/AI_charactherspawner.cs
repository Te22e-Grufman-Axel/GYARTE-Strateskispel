using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AI_charactherspawner : MonoBehaviour
{

    public GameObject Attacker;
    public GameObject Ai_1_Spawnpoint;
    public GameObject Ai_2_Spawnpoint;
    public GameObject Ai_3_Spawnpoint;
    public float timmer;
    GameObject NewObjectCild;
    public Transform parent;
    public string Tag;
    Vector3 SpawnRoation;
    Vector3 Spawnlocation_Ai_1;
        Vector3 Spawnlocation_Ai_2;
            Vector3 Spawnlocation_Ai_3;




private void Start() {
    Spawnlocation_Ai_1.Set(803,40,226);
      Spawnlocation_Ai_2.Set(247,40,213);
        Spawnlocation_Ai_3.Set(241,40,760);
}



    // Update is called once per frame
    void Update()
    {
        timmer = timmer + Time.deltaTime;

        if (timmer > 8)
        {
            timmer = 0;

            if (this.gameObject.tag == "Ai_1")
            {
                tag = "Ai_1";
                SpawnRoation.Set(0, 90, 0);
                Quaternion rotation = Quaternion.Euler(SpawnRoation);
                GameObject newObject = Instantiate(Attacker, Spawnlocation_Ai_1, rotation, parent);
                newObject.tag = Tag;
                newObject.transform.position = Ai_1_Spawnpoint.transform.position;
                Transform childTransform = newObject.transform.Find("Colider");
                childTransform.gameObject.tag = tag;
            }
            else if (this.gameObject.tag == "Ai_2")
            {
                tag = "Ai_2";
                SpawnRoation.Set(0, 90, 0);
                Quaternion rotation = Quaternion.Euler(SpawnRoation);
                GameObject newObject = Instantiate(Attacker, Spawnlocation_Ai_2, rotation, parent);
                newObject.tag = Tag;
                newObject.transform.position = Ai_1_Spawnpoint.transform.position;
                Transform childTransform = newObject.transform.Find("Colider");
                childTransform.gameObject.tag = tag;
            }
            else if (this.gameObject.tag == "Ai_3")
            {
                tag = "Ai_3";
                SpawnRoation.Set(0, 90, 0);
                Quaternion rotation = Quaternion.Euler(SpawnRoation);
                GameObject newObject = Instantiate(Attacker, Spawnlocation_Ai_3, rotation, parent);
                newObject.tag = Tag;
                newObject.transform.position = Ai_1_Spawnpoint.transform.position;
                Transform childTransform = newObject.transform.Find("Colider");
                childTransform.gameObject.tag = tag;
            }
        }
    }
}
