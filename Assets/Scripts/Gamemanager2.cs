using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;





// Retrieve the name of this scene.



public class Gamemanager2 : MonoBehaviour
{
    public static Gamemanager2 Instance { get; private set; }

    public int gameOutcome; // 1 = Win, 2 = Lose, 3 = Time Out
    public int numberOfDefenders;
    public int numberOfAttackers;
    public GameObject Greenflag;
    public GameObject Redflag;
    public GameObject Yellowflag;
    public GameObject Blueflag;
    public float timmer;
    public float time = 0;
    string sceneName;
    public PlayerCharacterSpawner PlayerCharacterSpawnerA;
    public PlayerCharacterSpawner PlayerCharacterSpawnerD;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void EndGame(int outcome, int defenders, int attackers)
    {
        Gamemanager2.Instance.gameOutcome = outcome;
        Gamemanager2.Instance.numberOfDefenders = defenders;
        Gamemanager2.Instance.numberOfAttackers = attackers;


        SceneManager.LoadScene("EndSceen");
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (PlayerCharacterSpawnerA != null && PlayerCharacterSpawnerD != null)
        {
            numberOfAttackers = PlayerCharacterSpawnerA.NumberOfAttackers;
            numberOfDefenders = PlayerCharacterSpawnerD.NumberOfDefenders;
        }


        if (Redflag == null && Greenflag == null && Yellowflag == null && sceneName == "Main")
        {
            EndGame(1, numberOfDefenders, numberOfAttackers);
        }
        else if (Blueflag == null && sceneName == "Main")
        {
            EndGame(2, numberOfDefenders, numberOfAttackers);
        }
        else if (time >= 300 && sceneName == "Main")
        {
            EndGame(3, numberOfDefenders, numberOfAttackers);
        }
        timmer = timmer + Time.deltaTime;

        if (timmer > 1)
        {
            timmer = 0;
            time++;
        }


        // Debug.Log(gameOutcome);
        // Debug.Log("sceneName" + sceneName);
    }
}
