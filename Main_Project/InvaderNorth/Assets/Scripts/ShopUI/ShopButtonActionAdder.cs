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
    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        buttonGotoLobby.onClick.AddListener(() => gameController.ChangeStage(StageType.LobbyStage));
        buttonGotoLevel1.onClick.AddListener(() => gameController.ChangeStage(StageType.Level1Stage));
        buttonGotoTutorial.onClick.AddListener(() => gameController.ChangeStage(StageType.TutorialStage));
    }
}
