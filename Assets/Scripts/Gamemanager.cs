using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int gameOutcome; // 1 = Win, 2 = Lose, 3 = Time Out
    public int numberOfDefenders;
    public int numberOfAttackers;

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
        GameManager.Instance.gameOutcome = outcome;
        GameManager.Instance.numberOfDefenders = defenders;
        GameManager.Instance.numberOfAttackers = attackers;

        SceneManager.LoadScene("EndScreen");
    }
}
