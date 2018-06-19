using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeController : MonoBehaviour
{
    private int gearType; //Inspector에서 연결된, LevelText의 번호를 가져와 어떤 종류인지 확인하는 Level
    private int playerGearLevel; //매니저에서 가져온 아이템이 어떤 종류인지 확인하고 넣어주는 아이템의 Level
    private int HadResource; //플레이어가 갖고 있는 재화

    public int GearUpgradeMaxLevel; //아이템의 Max Level 정보
    public int LevelPrice; // 아이템 레벨별 가격

    public Image UpgradeButton; //Max 레벨 시 업그레이드 버튼 비활성화를 위함

    public Text LevelText; //화면에서의 각 아이템 Level Text -> 0,1,2로 구별함
    public Text LevelCreditText; //화면에서의 ,업그레이드 비용 정보
    public Text PlayerResourceText; //화면에서, 플레이어 레벨 리소스 Text 변경을 위함

    public GameObject ChangedImage1;
    public GameObject ChangedImage2;
    public GameObject ChangedImage3;
    public GameObject ChangedImage4;

    private int[] changedConst = new int[3]; //이미지가 바뀌는 레벨 수치 정보 배열

    private struct UserInfo //플레이어의 hp, shot, critical 레벨정보, 재화 정보를 가져옴
    {
        public int hpLevel; //DataMaganager.DataInstance.gameData.hpLevel; 형식으로 불러와야 함
        public int shotLevel;
        public int criticalLevel;
        public int PlayerCredit;

        public void UserLevelValue()
        {
            this.hpLevel = 0;
            this.shotLevel = 5;
            this.criticalLevel = 20;
            this.PlayerCredit = 90000;
        }
    }

    private void Start()
    {
        changedConst[0] = 5;
        changedConst[1] = 10;
        changedConst[2] = 15;

        UserInfo userInfo = new UserInfo();
        userInfo.UserLevelValue();

        gearType = Int32.Parse(LevelText.text);
        HadResource = userInfo.PlayerCredit;

        if (gearType == 0)
        {
            playerGearLevel = userInfo.hpLevel;
        }
        else if (gearType == 1)
        {
            playerGearLevel = userInfo.shotLevel;
        }
        else if (gearType == 2)
        {
            playerGearLevel = userInfo.criticalLevel;
        }

        LevelText.text = playerGearLevel.ToString();
        PlayerResourceText.text = HadResource.ToString();

        upgradeCredit();
        ChangedConstImage();
        MaxLevel();
    }

    public void ChangeGear()
    {
        HadResource = Int32.Parse(PlayerResourceText.text);

        if (HadResource >= LevelPrice)
        {
            if (playerGearLevel < GearUpgradeMaxLevel)
            {
                LevelCreditText.text = "<color=#ffffff>" + LevelPrice + "</color>";

                HadResource = HadResource - LevelPrice;
                playerGearLevel++;

                LevelText.text = playerGearLevel.ToString();
                PlayerResourceText.text = HadResource.ToString();

                ChangedConstImage();
                upgradeCredit();
                MaxLevel();
            }
        }
        else
        {
            LevelCreditText.text = "<color=#ff0000>" + LevelPrice + "</color>";
        }
    }

    public void ChangedConstImage()
    {
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
        else { ChangedImage4.SetActive(true); }
    }

    public void MaxLevel()
    {
        if (playerGearLevel == GearUpgradeMaxLevel)
        {
            LevelCreditText.text = "-";
            UpgradeButton.enabled = false;
        }
    }

    public void upgradeCredit()
    {
        LevelPrice = 100 + (500 * playerGearLevel);
        LevelCreditText.text = LevelPrice.ToString();
    }
}