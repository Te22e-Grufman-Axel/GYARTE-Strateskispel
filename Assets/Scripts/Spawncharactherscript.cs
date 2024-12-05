using UnityEngine;

public class PlayerCharacterSpawner : MonoBehaviour
{
    public GameObject Attacker;
    public GameObject Defender;
    public Transform Parent;
    public int NumberOfAttackers = 0;
    public int NumberOfDefenders = 0;
    public string Tag = "Player";
    public Vector3 SpawnPosition = new Vector3(802, 51, 758);
    public Vector3 SpawnRotation = new Vector3(0, 90, 0);
    public GoldScript Gold;

    private void SpawnCharacter(GameObject characterPrefab, ref int count)
    {
        if (Gold.gold >= 5)
        {
            Gold.gold -= 5;
            Quaternion rotation = Quaternion.Euler(SpawnRotation);
            GameObject newObject = Instantiate(characterPrefab, SpawnPosition, rotation, Parent);
            newObject.tag = Tag;

            Collider collider = newObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.isTrigger = true;
            }

            count++;
        }
    }

    public void SpawnAttacker()
    {
        SpawnCharacter(Attacker, ref NumberOfAttackers);
    }

    public void SpawnDefender()
    {
        SpawnCharacter(Defender, ref NumberOfDefenders);
    }
}
