using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

    public GameModel gameModel;
    public GameView gameView;

    public void Start()
    {
        InputManager.inputInstance.Register(new InputButtonCallBack(CreateLoginAccount));
    }

    public void VerifyLoginData(string id, string password)
    {
        gameModel.LoadSuccessCallBack = IsDataLoaded;
        gameModel.IsLoginDataExist(id, password);
    }

    public void IsDataLoaded(bool check)
    {
        if(check == true)
        {
            Debug.Log("로그인 성공");
            StageManager.stageInstance.ChangeStage();
        }
        else
        {
            Debug.Log("로그인 실패");
        }
    }

    public void CreateLoginAccount(string id, string password, InputType inputType)
    {
        gameModel.MakeNewAccount(id, password);
    }
}
