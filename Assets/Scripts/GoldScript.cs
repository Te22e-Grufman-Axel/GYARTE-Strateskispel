using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldScript : MonoBehaviour
{
    public int gold = 0;
    public TextMeshProUGUI GoldText;

    float timmer;




    void Update()
    {

        GoldText.text = "Gold: " + gold;

        timmer = timmer + Time.deltaTime;

        if(timmer > 1)
        {
            timmer = 0;
            gold++;
        }

    }



}
