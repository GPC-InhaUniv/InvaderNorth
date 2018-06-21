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
        if(stageType == StageType.LoadingStage)
        {
            gameView = GameObject.Find("LoadingStageView").GetComponent<SignStageView>();
        }
        else if(stageType == StageType.ShopStage)
        {
            gameView = GameObject.Find("ShopStageView").GetComponent<SignStageView>();
        }
        else if(stageType == StageType.LobbyStage)
        {
            gameView = GameObject.Find("LobbyStageView").GetComponent<SignStageView>();
        }
        else if(stageType == StageType.TutorialStage)
        {
            gameView = GameObject.Find("TutorialStageView").GetComponent<SignStageView>();
        }
        else if(stageType == StageType.CombatStage)
        {
            gameView = GameObject.Find("CombatStageView").GetComponent<SignStageView>();
        }
        else
        {
            return;
        }
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
