using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeController : MonoBehaviour
{
    private int gearLevel;
    private int playerGearLevel;
    private int playerResource;

    public int GearUpgradeMaxLevel;
    public int LevelResourcePrice;

    public Image UpgradeButton;

    public Text LevelText;
    public Text LevelResourceText;
    public Text PlayerResourceText;

    public GameObject ChangedImage1;
    public GameObject ChangedImage2;
    public GameObject ChangedImage3;
    public GameObject ChangedImage4;

    private int[] changedConst = new int[3];

    [SerializeField]
    private struct UserInfo //user의 hp, shot, critical 레벨을 가져온다.
    {
        public int hpLevel;
        public int shotLevel;
        public int criticalLevel;
        public int PlayerResource;

        public void UserLevelValue()
        {
            this.hpLevel = 5;
            this.shotLevel = 3;
            this.criticalLevel = 1;
        }
    }

    private void Start()
    {
        changedConst[0] = 5;
        changedConst[1] = 10;
        changedConst[2] = 15;

        UserInfo userInfo = new UserInfo();
        userInfo.UserLevelValue();

        gearLevel = Int32.Parse(LevelText.text);

        if (gearLevel == 0)
        {
            playerGearLevel = userInfo.hpLevel;
        }

        if (gearLevel == 1)
        {
            playerGearLevel = userInfo.shotLevel;
        }

        if (gearLevel == 2)
        {
            playerGearLevel = userInfo.criticalLevel;
        }
        LevelText.text = playerGearLevel.ToString();
    }

    public void ChangeGear()
    {
        playerResource = Int32.Parse(PlayerResourceText.text);

        if (playerResource >= LevelResourcePrice)
        {
            if (playerGearLevel < GearUpgradeMaxLevel)
            {
                LevelResourceText.text = "<color=#ffffff>" + LevelResourcePrice + "</color>";

                playerResource = playerResource - LevelResourcePrice;
                gearLevel++;
                LevelResourcePrice = LevelResourcePrice + 500;

                LevelText.text = gearLevel.ToString();
                LevelResourceText.text = LevelResourcePrice.ToString();
                PlayerResourceText.text = playerResource.ToString();
            }

            if (playerGearLevel < changedConst[0])
            {
                ChangedImage1.SetActive(true);
            }
            else if (playerGearLevel == changedConst[0])
            {
                ChangedImage2.SetActive(true);
                ChangedImage1.SetActive(false);
            }
            else if (playerGearLevel == changedConst[1])
            {
                ChangedImage3.SetActive(true);
                ChangedImage2.SetActive(false);
            }
            else if (playerGearLevel == changedConst[2])
            {
                ChangedImage4.SetActive(true);
                ChangedImage3.SetActive(false);
            }

            if (playerGearLevel == GearUpgradeMaxLevel)
            {
                LevelResourceText.text = "-";
                UpgradeButton.enabled = false;
            }
        }
        else
        {
            LevelResourceText.text = "<color=#ff0000>" + LevelResourcePrice + "</color>";
        }
    }
}