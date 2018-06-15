using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataDisplayController : MonoBehaviour
{
    //public _GameData gamedata; 임시데이터였음
    public Text ValueNumberText;
    private void Awake()
    {
        ValueNumberText = GetComponent<Text>();
    }

    void Start()
    {
        
    }
    //바뀌는지 확인하기 위해 \Update에 임시 작성
    void Update()
    {
        switch(gameObject.name)
        {
            case "HaveFuelAmountText":
                UpdateFuelData();
                break;

            case "ResourceAmountText":
                UpdateResourceData();
                break;

            case "HighestScoreTextNumber":
                UpdateHighestScoreData();
                break;

            case "TotalScoreTextNumber":
                UpdateTotalScoreData();
                break;

            case "ArchievementText":
                UpdateArchievement();
                break;

            default:
                Debug.Log("해당 값이 들어오지 않았습니다.");
                break;
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
