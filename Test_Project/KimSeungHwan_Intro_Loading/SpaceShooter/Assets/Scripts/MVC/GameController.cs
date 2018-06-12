using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

    public GameModel gameModel;
    public GameView gameView;

    public void Start()
    {
        //InputManager.inputInstance.Register(new InputButtonCallBack(CreateLoginAccount));
    }

    public void VerifyLoginData(string id, string password)
    {
        gameModel.LoadSuccessCallBack = DataLoaded;
        gameModel.LoadFailCallBack = DataNotLoaded;
        gameModel.IsLoginDataExist(id, password);
    }

    public void DataLoaded()
    {
        Debug.Log("로그인 성공");
        StageManager.stageInstance.ChangeStage();
    }

    public void DataNotLoaded(LoginProcessType loginProcessType)
    {
        if(loginProcessType == LoginProcessType.NoAccount)
        {
            gameView.ShowPopUp("계정이 존재하지 않습니다");
        }
        if (loginProcessType == LoginProcessType.WrongPassword)
        {
            gameView.ShowPopUp("비밀번호가 틀렸습니다");
        }
    }

    public void CreateLoginAccount(string id, string password)
    {
        gameModel.createSuccessCallBack = IsAccountCreadted;
        gameModel.MakeNewAccount(id, password);
    }

    public void IsAccountCreadted()
    {
        Debug.Log("계정 생성");
    }
}
