using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI outcomeText;       // Drag and drop the UI Text for the outcome message
    public TextMeshProUGUI defendersText;    // Drag and drop the UI Text for defenders
    public TextMeshProUGUI attackersText;    // Drag and drop the UI Text for attackers

    private void Start()
    {
        // Display outcome message
        switch (GameManager.Instance.gameOutcome)
        {
            case 1:
                outcomeText.text = "You Win!";
                break;
            case 2:
                outcomeText.text = "You Lose!";
                break;
            case 3:
                outcomeText.text = "Time's Up!";
                break;
            default:
                outcomeText.text = "Game Over";
                break;
        }

        // Display number of defenders and attackers
        defendersText.text = "Number of Defenders: " + GameManager.Instance.numberOfDefenders;
        attackersText.text = "Number of Attackers: " + GameManager.Instance.numberOfAttackers;
    }
}
