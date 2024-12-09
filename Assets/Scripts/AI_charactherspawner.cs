using UnityEngine;

public class AICharacterSpawner : MonoBehaviour
{
    public GameObject Attacker;
    public GameObject SpawnPointAI1;
    public GameObject SpawnPointAI2;
    public GameObject SpawnPointAI3;
    public Transform Parent;
    public GameObject KnightAIReference;

    public float Timer;
    public float SpawnInterval = 8f;
    public string DefaultTag;
    public string ColliderTag;

    private readonly Vector3 Rotation = new Vector3(0, 90, 0);

    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > SpawnInterval)
        {
            Timer = 0;
            Vector3 spawnPosition;
            GameObject spawnPoint;

            if (tag == "Ai_1")
            {
                spawnPosition = SpawnPointAI1.transform.position;
                spawnPoint = SpawnPointAI1;
            }
            else if (tag == "Ai_2")
            {
                spawnPosition = SpawnPointAI2.transform.position;
                spawnPoint = SpawnPointAI2;
            }
            else if (tag == "Ai_3")
            {
                spawnPosition = SpawnPointAI3.transform.position;
                spawnPoint = SpawnPointAI3;
            }
            else
            {
                return;
            }

            SpawnAttacker(spawnPosition, spawnPoint);
        }
    }

    private void SpawnAttacker(Vector3 spawnPosition, GameObject spawnPoint)
    {
        Quaternion rotation = Quaternion.Euler(Rotation);
        GameObject newObject = Instantiate(Attacker, spawnPosition, rotation, Parent);
        newObject.tag = DefaultTag;

        newObject.transform.position = spawnPoint.transform.position;

        Collider collider = newObject.GetComponent<Collider>();
        collider.isTrigger = true;

        Transform childTransform = newObject.transform.Find("Colider");

        Collider childCollider = childTransform.GetComponent<Collider>();
        childCollider.isTrigger = true;
        childTransform.gameObject.tag = ColliderTag;


        Knight_Ai knightAI = newObject.GetComponent<Knight_Ai>();
        knightAI.D_Knight_Ai = KnightAIReference.GetComponent<D_Knight_Ai>();


    }
}
