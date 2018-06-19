using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataDisplayController : MonoBehaviour
{
    private int FuelAmount;
    private int ResourceAmount;
    private int HighestScore;
    private int TotalScore;
    private string Archievement;

    public Text ValueNumberText;
    private void Awake()
    {
        ValueNumberText = GetComponent<Text>();
    }

    void Start()
    {
        FuelAmount = 1;
        ResourceAmount = 2;
        HighestScore = 3;
        TotalScore = 4;
        Archievement = "setArc";
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
       
       ValueNumberText.text = FuelAmount.ToString();
    }

    void UpdateResourceData()
    {
       ValueNumberText.text = ResourceAmount.ToString();
    }
    
    void UpdateHighestScoreData()
    {
       ValueNumberText.text = HighestScore.ToString();
    }

    void UpdateTotalScoreData()
    {
       ValueNumberText.text = TotalScore.ToString();
    }

    void UpdateArchievement()
    {
       ValueNumberText.text = Archievement.ToString();
    }
}
