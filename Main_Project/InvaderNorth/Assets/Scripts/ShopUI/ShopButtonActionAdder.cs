using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonActionAdder : MonoBehaviour {

    [SerializeField]
    private Button buttonGotoLobby;
    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        buttonGotoLobby.onClick.AddListener(() => gameController.ChangeStage(StageType.LobbyStage));
    }
}
