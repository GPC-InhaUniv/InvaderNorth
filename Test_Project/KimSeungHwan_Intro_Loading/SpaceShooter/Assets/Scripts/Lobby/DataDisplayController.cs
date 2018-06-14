using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataDisplayController : MonoBehaviour
{
    //public _GameData gamedata; 임시데이터였음
    public Text ValueNumberText;
   
    
    void Start()
    {
        ValueNumberText = GetComponent<Text>();
    }
    //바뀌는지 확인하기 위해 \Update에 임시 작성
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

        if(gameObject.name == "ArchievementText")
        {
            UpdateArchievement();
        }
    }

    void UpdateFuelData()
    {
       
       // ValueNumberText.text = gamedata.fuelAmount.ToString();
    }

    void UpdateResourceData()
    {
       // ValueNumberText.text = gamedata.resourceAmount.ToString();
    }
    
    void UpdateHighestScoreData()
    {
       // ValueNumberText.text = gamedata.highestScore.ToString();
    }

    void UpdateTotalScoreData()
    {
       // ValueNumberText.text = gamedata.totalScore.ToString();
    }

    void UpdateArchievement()
    {
       // ValueNumberText.text = gamedata.Archievement.ToString();
    }
}
