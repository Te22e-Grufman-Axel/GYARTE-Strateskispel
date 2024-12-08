using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI outcomeText;
    public TextMeshProUGUI defendersText;
    public TextMeshProUGUI attackersText;

    private void Start()
    {
        if (Gamemanager2.Instance.gameOutcome == 1)
        {
            outcomeText.text = "You Win!";
        }
        else if (Gamemanager2.Instance.gameOutcome == 2)
        {
            outcomeText.text = "You Lose!";
        }

        else if (Gamemanager2.Instance.gameOutcome == 3)
        {
            outcomeText.text = "Time's Up!";
        }
        else
        {
            outcomeText.text = "Game Over";
        }

        defendersText.text = "Number of Defenders: " + Gamemanager2.Instance.numberOfDefenders;
        attackersText.text = "Number of Attackers: " + Gamemanager2.Instance.numberOfAttackers;
    }
}
