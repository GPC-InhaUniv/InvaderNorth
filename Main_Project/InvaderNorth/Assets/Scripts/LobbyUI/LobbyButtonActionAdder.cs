using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyButtonActionAdder : MonoBehaviour {

    [SerializeField]
    private Button buttonGotoShop;
    private GameController gameController;

    private void Awake ()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        buttonGotoShop.onClick.AddListener(() => gameController.ChangeStage(StageType.ShopStage));
    }
}
