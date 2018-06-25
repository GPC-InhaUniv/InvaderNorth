using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopStageView : MonoBehaviour, IShowable
{
    private int gearSlot;
    private int playerGearLevel;
    private int HadCredit;
    private int gearLevelPrice;

    private const int MAXHPLEVEL = 10;
    private const int MAXBULLETLEVEL = 20;
    private const int MAXCRITLEVEL = 20;

    [Header("UpgradeButton")]
    [SerializeField]
    private Image[] upgradeButton;

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

    [Header("GearImage")]
    [SerializeField]
    private GameObject[] HeartImage;
    private GameObject[] BulletImage;
    private GameObject[] CriticalShotImage;

    public void ShowInformation(GameData gameData)
    {
        int totalLevel = gameData.hpLevel + gameData.bulletLevel + gameData.critLevel;

        HeartLevelText.text = gameData.hpLevel.ToString();
        ShotLevelText.text = gameData.bulletLevel.ToString();
        CriticalLevelText.text = gameData.critLevel.ToString();
        PlayerLevelText.text = totalLevel.ToString();

        playerCreditText.text = gameData.credit.ToString();
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
                    informationBox[2].SetActive(true);
                }
                else
                {
                    informationBox[2].SetActive(false);
                }
                break;
            }
        }
    }

    public void ChangeConstImage()
    {

    }

    public void ShowMaxLevel()
    {

    }
    
}