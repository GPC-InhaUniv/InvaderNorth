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
    private Text playerLevelText;

    [Header("ToolTip")]
    [SerializeField]
    private GameObject[] informationBox;

    [Header("Gear Level")]
    [SerializeField]
    private Text heartLevelText;
    [SerializeField]
    private Text shotLevelText;
    [SerializeField]
    private Text criticalLevelText;

    [Header("Upgrade Cost")]
    [SerializeField]
    private Text hpCostText;
    [SerializeField]
    private Text bulletCostText;
    [SerializeField]
    private Text criticalShotCostText;

    [Header("PlayerCredit")]
    [SerializeField]
    private Text playerCreditText;

    [Header("GearBox")]
    [SerializeField]
    private GameObject heartBox;
    [SerializeField]
    private GameObject bulletBox;
    [SerializeField]
    private GameObject criticalShotBox;

    [Header("GearImage")]
    [SerializeField]
    private Sprite[] heartImage;
    [SerializeField]
    private Sprite[] bulletImage;
    [SerializeField]
    private Sprite[] criticalShotImage;

    public void ShowInformation(GameData gameData)
    {
        int totalLevel = gameData.hpLevel + gameData.bulletLevel + gameData.critLevel;

        heartLevelText.text = gameData.hpLevel.ToString();
        shotLevelText.text = gameData.bulletLevel.ToString();
        criticalLevelText.text = gameData.critLevel.ToString();
        playerLevelText.text = totalLevel.ToString();

        playerCreditText.text = gameData.credit.ToString();

        if(gameData.hpLevel >= MAXHPLEVEL)
        {
            ShowMaxLevel(UpgradeType.Heart);
        }
        else
        {
            hpCostText.text = (100 + gameData.hpLevel * 50).ToString();
        }

        if (gameData.bulletLevel >= MAXBULLETLEVEL)
        {
            ShowMaxLevel(UpgradeType.Bullet);
        }
        else
        {
            bulletCostText.text = (100 + gameData.bulletLevel * 50).ToString();
        }

        if (gameData.critLevel >= MAXCRITLEVEL)
        {
            ShowMaxLevel(UpgradeType.CriticalShot);
        }
        else
        {
            criticalShotCostText.text = (100 + gameData.critLevel * 50).ToString();
        }

        DrawGearBox(gameData);
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

    public void ShowMaxLevel(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.Heart:
                {
                    hpCostText.text = "-";
                    break;
                }

            case UpgradeType.Bullet:
                {
                    bulletCostText.text = "-";
                    break;
                }
            case UpgradeType.CriticalShot:
                {
                    criticalShotCostText.text = "-";
                    break;
                }
        }
    }
    
    private void DrawGearBox(GameData gameData)
    {
        if(gameData.hpLevel < 3)
        {
            heartBox.GetComponent<Image>().sprite = heartImage[0];
        }
        else if (gameData.hpLevel < 6)
        {
            heartBox.GetComponent<Image>().sprite = heartImage[1];
        }
        else if (gameData.hpLevel < 10)
        {
            heartBox.GetComponent<Image>().sprite = heartImage[2];
        }
        else
        {
            heartBox.GetComponent<Image>().sprite = heartImage[3];
        }

        if (gameData.bulletLevel < 6)
        {
            bulletBox.GetComponent<Image>().sprite = bulletImage[0];
        }
        else if (gameData.bulletLevel < 12)
        {
            bulletBox.GetComponent<Image>().sprite = bulletImage[1];
        }
        else if (gameData.bulletLevel < 20)
        {
            bulletBox.GetComponent<Image>().sprite = bulletImage[2];
        }
        else
        {
            bulletBox.GetComponent<Image>().sprite = bulletImage[3];
        }

        if (gameData.critLevel < 6)
        {
            criticalShotBox.GetComponent<Image>().sprite = criticalShotImage[0];
        }
        else if (gameData.critLevel < 12)
        {
            criticalShotBox.GetComponent<Image>().sprite = criticalShotImage[1];
        }
        else if (gameData.critLevel < 20)
        {
            criticalShotBox.GetComponent<Image>().sprite = criticalShotImage[2];
        }
        else
        {
            criticalShotBox.GetComponent<Image>().sprite = criticalShotImage[3];
        }
    }
}