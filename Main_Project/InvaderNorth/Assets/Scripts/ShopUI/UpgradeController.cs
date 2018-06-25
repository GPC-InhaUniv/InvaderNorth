using UnityEngine;
using UnityEngine.UI;
using System;

public enum UpgradeType
{
    Heart,
    Bullet,
    CriticalShot
}

public class UpgradeController : MonoBehaviour
{
    private int heartCost;
    private int bulletCost;
    private int CriticalShotCost;

    private int[] changedConst = new int[4];

    private GameController gameController;

    private GameData userData;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gameController.RequestShowInformation();
        userData = DataManager.Datainstance.gameData;
    }

    public void OnUpgradeButtonClick(UpgradeType upgradeType)
    {
        switch(upgradeType)
        {
            case UpgradeType.Heart:
            {
                if(heartCost <= userData.credit)
                {
                    gameController.PurchaseItem(heartCost, upgradeType);
                }
                break;
            }
            case UpgradeType.Bullet:
            {
                if (bulletCost <= userData.credit)
                {
                    gameController.PurchaseItem(heartCost, upgradeType);
                }
                break;
            }
            case UpgradeType.CriticalShot:
            {
                if (bulletCost <= userData.credit)
                {
                    gameController.PurchaseItem(heartCost, upgradeType);
                }
                break;
            }
        }
    }

    public void ShowToolTip(PopUpType popupType)
    {
        gameController.RequestShowPopUp(popupType);
    }
}