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
    private const int MAXHPLEVEL = 10;
    private const int MAXBULLETLEVEL = 20;
    private const int MAXCRITLEVEL = 20;

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

        heartCost = 100 + userData.hpLevel * 50;
        bulletCost = 100 + userData.bulletLevel * 50;
        CriticalShotCost = 100 + userData.critLevel * 50;
    }

    public void OnUpgradeButtonClick(UpgradeType upgradeType)
    {
        switch(upgradeType)
        {
            case UpgradeType.Heart:
            {
                if(heartCost <= userData.credit && userData.hpLevel < MAXHPLEVEL)
                {
                    gameController.PurchaseItem(heartCost, upgradeType);
                }
                break;
            }
            case UpgradeType.Bullet:
            {
                if (bulletCost <= userData.credit && userData.bulletLevel < MAXBULLETLEVEL)
                {
                    gameController.PurchaseItem(heartCost, upgradeType);
                }
                break;
            }
            case UpgradeType.CriticalShot:
            {
                if (bulletCost <= userData.credit && userData.critLevel < MAXCRITLEVEL)
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