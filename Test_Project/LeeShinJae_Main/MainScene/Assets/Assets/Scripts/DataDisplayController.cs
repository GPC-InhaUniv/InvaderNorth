using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataDisplayController : MonoBehaviour
{
    public _GameData gamedata;
    public Text valueNumberText;
   
    
    private void Start()
    {
        valueNumberText = GetComponent<Text>();
    }

    void Update()
    {
        if (gameObject.name == "HaveFuelAmountText")
        {
            UpdateFuelData();
        }

        if(gameObject.name == "ResourceAmountText")
        {
            UpdateResourceData();
        }

        if (gameObject.name == "HighestScoreTextNumber")
        {
            UpdateHighestScoreData();
        }

        if (gameObject.name == "TotalScoreTextNumber")
        {
            UpdateTotalScoreData();
        }
    }

    void UpdateFuelData()
    {
        valueNumberText.text = gamedata.fuelAmount.ToString();
    }

    void UpdateResourceData()
    {
        valueNumberText.text = gamedata.resourceAmount.ToString();
    }
    
    void UpdateHighestScoreData()
    {
        valueNumberText.text = gamedata.highestScore.ToString();
    }

    void UpdateTotalScoreData()
    {
        valueNumberText.text = gamedata.totalScore.ToString();
    }

   
}
