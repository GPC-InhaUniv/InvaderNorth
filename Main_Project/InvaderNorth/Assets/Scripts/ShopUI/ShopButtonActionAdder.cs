using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonActionAdder : MonoBehaviour {

    [SerializeField]
    private Button buttonGotoLobby;
    [SerializeField]
    private Button buttonGotoLevel1;
    [SerializeField]
    private Button buttonGotoTutorial;
    [SerializeField]
    private Button buttonHeartPopUp;
    [SerializeField]
    private Button buttonBulletPopUp;
    [SerializeField]
    private Button buttonCriticalPopUp;

    private GameController gameController;
    private UpgradeController upgradeController;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        upgradeController = GameObject.Find("UpgradeController").GetComponent<UpgradeController>();

        buttonGotoLobby.onClick.AddListener(() => gameController.ChangeStage(StageType.LobbyStage));
        buttonGotoLevel1.onClick.AddListener(() => gameController.ChangeStage(StageType.Level1Stage));
        buttonGotoTutorial.onClick.AddListener(() => gameController.ChangeStage(StageType.TutorialStage));

        buttonHeartPopUp.onClick.AddListener(() => upgradeController.ShowToolTip(PopUpType.HeartToolTip));
        buttonBulletPopUp.onClick.AddListener(() => upgradeController.ShowToolTip(PopUpType.BulletToolTip));
        buttonCriticalPopUp.onClick.AddListener(() => upgradeController.ShowToolTip(PopUpType.CriticalToolTip));
    }
}
