using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeController : MonoBehaviour
{
    private int gearSlot; //Inspector에서 연결된, LevelText의 번호를 가져와 어떤 종류인지 확인하는 Level
    private int playerGearLevel; //매니저에서 가져온 아이템이 어떤 종류인지 확인하고 넣어주는 아이템의 Level
    private int HadCredit; //플레이어가 갖고 있는 재화
    private int gearLevelPrice; // 아이템 레벨별 가격

    [Header("UpgradeButton")]
    [SerializeField]
    private Image upgradeButton; //Max 레벨 시 업그레이드 버튼 비활성화를 위함

    [Header("Credit Imformation")]
    [SerializeField]
    private int gearUpgradeMaxLevel; //아이템의 Max Level 정보

    [SerializeField]
    private Text gearLevelText; //화면에서의 각 아이템 Level Text -> 0,1,2로 구별함

    [SerializeField]
    private Text upgradeCreditText; //화면에서의 ,업그레이드 비용 정보

    [SerializeField]
    private Text playerCreditText; //화면에서, 플레이어 레벨 리소스 Text 변경을 위함

    [Header("Gear Image")]
    [SerializeField]
    private GameObject[] levelImages;

    private int[] changedConst = new int[4];

    //DataManager.datainstance 에 접근하면 사용 안함
    private struct UserInfo
    {
        public const int maxHpLevel = 10;
        public const int maxBulletLevel = 20;
        public const int maxCritLevel = 20;

        public int hpLevel;
        public int bulletLevel;
        public int critLevel;
        public int credit;

        public void UserLevelValue()
        {
            hpLevel = 0;
            bulletLevel = 0;
            critLevel = 0;
            credit = 900000;
        }
    }

    private void Start()
    {
        changedConst[0] = gearUpgradeMaxLevel - (gearUpgradeMaxLevel - gearUpgradeMaxLevel / 5);
        changedConst[1] = gearUpgradeMaxLevel - gearUpgradeMaxLevel / 2 - 1;
        changedConst[2] = gearUpgradeMaxLevel - gearUpgradeMaxLevel / 5 - 1;
        changedConst[3] = gearUpgradeMaxLevel + 1;

        UserInfo userInfo = new UserInfo();
        userInfo.UserLevelValue();

        gearSlot = Int32.Parse(gearLevelText.text);
        HadCredit = userInfo.credit;

        if (gearSlot == 0)
        {
            playerGearLevel = userInfo.hpLevel;
            gearUpgradeMaxLevel = UserInfo.maxHpLevel;
        }
        else if (gearSlot == 1)
        {
            playerGearLevel = userInfo.bulletLevel;
            gearUpgradeMaxLevel = UserInfo.maxBulletLevel;
        }
        else if (gearSlot == 2)
        {
            playerGearLevel = userInfo.critLevel;
            gearUpgradeMaxLevel = UserInfo.maxCritLevel;
        }

        gearLevelText.text = playerGearLevel.ToString();
        playerCreditText.text = HadCredit.ToString();

        upgradeCredit();
        ChangedConstImage();
        MaxLevel();
    }

    public void OnChangeGear()
    {
        HadCredit = Int32.Parse(playerCreditText.text);

        if (HadCredit >= gearLevelPrice)
        {
            if (playerGearLevel < gearUpgradeMaxLevel)
            {
                upgradeCreditText.text = "<color=#ffffff>" + gearLevelPrice + "</color>";

                HadCredit = HadCredit - gearLevelPrice;
                playerGearLevel++;

                gearLevelText.text = playerGearLevel.ToString();
                playerCreditText.text = HadCredit.ToString();

                ChangedConstImage();
                upgradeCredit();
                MaxLevel();
            }
        }
        else
        {
            upgradeCreditText.text = "<color=#ff0000>" + gearLevelPrice + "</color>";
        }
    }

    public void ChangedConstImage()
    {
        if (playerGearLevel <= changedConst[0])
        {
            levelImages[0].SetActive(true);
        }
        else if (playerGearLevel <= changedConst[1])
        {
            levelImages[1].SetActive(true);
            levelImages[0].SetActive(false);
        }
        else if (playerGearLevel < changedConst[2])
        {
            levelImages[2].SetActive(true);
            levelImages[1].SetActive(false);
        }
        else if (playerGearLevel < changedConst[3])
        {
            levelImages[3].SetActive(true);
            levelImages[2].SetActive(false);
        }
    }

    public void MaxLevel()
    {
        if (playerGearLevel == gearUpgradeMaxLevel)
        {
            upgradeCreditText.text = "-";
            upgradeButton.enabled = false;
        }
    }

    public void upgradeCredit()
    {
        gearLevelPrice = 100 + (500 * playerGearLevel);
        upgradeCreditText.text = gearLevelPrice.ToString();
    }
}