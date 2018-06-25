using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopStageView : MonoBehaviour, IShowable
{
    [Header("PlayerTotalLevel")]
    [SerializeField]
    private Text PlayerLevelText;

    [Header("ToolTip")]
    [SerializeField]
    private GameObject[] informationBox;

    [Header("Gear Level")]
    [SerializeField]
    private Text HeartLevelText;
    [SerializeField]
    private Text ShotLevelText;
    [SerializeField]
    private Text CriticalLevelText;

    [Header("PlayerCredit")]
    [SerializeField]
    private Text playerCreditText;

    public void ShowInformation(GameData gameData)
    {
        int totalLevel = gameData.hpLevel + gameData.bulletLevel + gameData.critLevel;

        playerCreditText.text = gameData.credit.ToString();

        PlayerLevelText.text = totalLevel.ToString();
    }

    public void ShowPopUp(PopUpType popupType)
    {
        switch (popupType)
        {
            case PopUpType.HeartToolTip:
            {
                if (informationBox[0].activeSelf == false)
                {
                    informationBox[0].SetActive(true);
                }
                else
                {
                    informationBox[0].SetActive(false);
                }
                break;
            }

            case PopUpType.BulletToolTip :
            {
                if (informationBox[1].activeSelf == false)
                {
                    informationBox[1].SetActive(true);
                }
                else
                {
                    informationBox[1].SetActive(false);
                }

                break;
            }
            case PopUpType.CriticalToolTip:
            {
                if (informationBox[2].activeSelf == false)
                {
                    informationBox[0].SetActive(true);
                }
                else
                {
                    informationBox[0].SetActive(false);
                }
                break;
            }
        }
    }
    
}