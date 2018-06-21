using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

    [SerializeField]
    private GameModel gameModel;
    [SerializeField]
    private IShowable gameView;

    private void Start()
    {
        gameView = GameObject.Find("SignStageView").GetComponent<SignStageView>();
        StageManager.stageInstance.sceneChangedCallBack = SetGameView;
    }
    
    public void SetGameView(StageType stageType)
    {
        gameView = GameObject.Find("SignStageView").GetComponent<SignStageView>();
    }

    public void VerifyAccountData(string id, string password)
    {
        gameModel.LoadSuccessCallBack = DataLoaded;
        gameModel.LoadFailCallBack = DataNotLoaded;
        gameModel.IsLoginDataExist(id, password);
    }

    public void DataLoaded()
    {
        Debug.Log("로그인 성공");
        StartCoroutine(StageManager.stageInstance.ChangeStageCoroutine(StageType.LobbyStage));
    }

    public void DataNotLoaded(SignInProcessType loginProcessType)
    {
        if(loginProcessType == SignInProcessType.NoAccount)
        {
            gameView.ShowPopUp(PopUpType.SignInNoAccount);
        }
        if (loginProcessType == SignInProcessType.WrongPassword)
        {
            gameView.ShowPopUp(PopUpType.SignInWrongPassword);
        }
    }

    public void CreateAccount(string id, string password)
    {
        if(id == null || id.Length < 6)
        {
            gameView.ShowPopUp(PopUpType.SignUpIdError);
        }
        else if(password.Length < 6)
        {
            gameView.ShowPopUp(PopUpType.SignUpPasswordError);
        }
        else
        {
            gameModel.createSuccessCallBack = AccountCreated;
            gameModel.createFailCallBack = AccountNotCreadted;
            gameModel.MakeNewAccount(id, password);
        }
    }

    public void AccountCreated()
    {
        gameView.ShowPopUp(PopUpType.SignUpSuccess);
    }

    public void AccountNotCreadted()
    {
        gameView.ShowPopUp(PopUpType.SignUpExistingAccount);
    }
}
