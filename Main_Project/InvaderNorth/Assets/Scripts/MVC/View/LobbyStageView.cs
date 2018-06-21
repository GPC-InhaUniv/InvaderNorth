using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyStageView : MonoBehaviour, IShowable
{
    [Header("Lobby UI Attribute")]
    [SerializeField]
    private Text fuelAmountText;
    [SerializeField]
    private Text resourceAmountText;
    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private Text totalScoreText;
    [SerializeField]
    private Text ArchivementText;

    public void ShowPopUp(PopUpType popUptype)
    {
        
    }

    public void ShowInformation(GameData gameData)
    {
        resourceAmountText.text = gameData.credit.ToString();
        highScoreText.text = gameData.highestScore.ToString();
        totalScoreText.text = gameData.totalScore.ToString();
        ArchivementText.text = "뉴비 우주 모험가";
    }
}
