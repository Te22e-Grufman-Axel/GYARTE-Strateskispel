using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldScript : MonoBehaviour
{
    public int gold = 0;
    public TextMeshProUGUI GoldText;






    void Update()
    {

        GoldText.text = "Gold: " + gold;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gold++;
        }
    }



}
