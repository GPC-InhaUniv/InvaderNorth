using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonActionAdder : MonoBehaviour {

    [SerializeField]
    private Button buttonGotoLobby;
    [SerializeField]
    private Button buttonGotoCombat;
    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        buttonGotoLobby.onClick.AddListener(() => gameController.ChangeStage(StageType.LobbyStage));
        buttonGotoCombat.onClick.AddListener(() => gameController.ChangeStage(StageType.CombatStage));
    }
}
