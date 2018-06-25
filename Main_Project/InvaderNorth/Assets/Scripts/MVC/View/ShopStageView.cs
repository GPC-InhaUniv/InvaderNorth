using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopStageView : MonoBehaviour, IShowable
{
    [Header("01.PlayerLevelController")]
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

    [Header("02.PlayerLevelController")]
    [Header("PlyaerTotalLevel")]
    [SerializeField]
    private Text PlayerLevelText;

    [Header("Gear Level")]
    [SerializeField]
    private Text HeartLevelText;

    [SerializeField]
    private Text ShotLevelText;

    [SerializeField]
    private Text CriticalLevelText;

    private int[] changedConst = new int[4];

    [Header("03.InformationController")]
    [Header("InformationBox")]
    [SerializeField]
    private GameObject informationBox;

    public enum InformationType
    {
        HeartTip,
        BulletTip,
        CriticalTip,
    }

    public void ShowPopUp(PopUpType popUptype)
    {
    }

    public void ShowImpormationToolTip(InformationType informationType) //i 버튼을 눌렀을 때, 팝업을 보여줌.
    {
        if (informationType == InformationType.HeartTip)
        {
            informationBox.SetActive(true);
        }
        else
        {
            return;
        }
    }

    public void ShowInformation(GameData gameData)
    {
    }

    public void setHpTextValue(int level)
    {
    }

    public void setBulletTextValue(int level)
    {
    }

    public void setCriTextValue(int level)
    {
    }
}