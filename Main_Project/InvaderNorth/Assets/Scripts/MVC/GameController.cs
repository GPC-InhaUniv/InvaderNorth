using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

    [SerializeField]
    private GameModel gameModel;
    private IShowable gameView;
    private StageType targetStage;

    private void Start()
    {
        gameView = GameObject.Find("SignStageView").GetComponent<SignStageView>();
        StageManager.stageInstance.sceneChangedCallBack = SetGameView;
    }
    
    public void SetGameView(StageType stageType)
    {
        if(stageType == StageType.ShopStage)
        {
            gameView = GameObject.Find("ShopStageView").GetComponent<ShopStageView>();
            gameView.ShowInformation(gameModel.GetGameData());
        }
        else if(stageType == StageType.LobbyStage)
        {
            gameView = GameObject.Find("LobbyStageView").GetComponent<LobbyStageView>();
            gameView.ShowInformation(gameModel.GetGameData());
        }
        else if(stageType == StageType.TutorialStage)
        {
            //gameView = GameObject.Find("TutorialStageView").GetComponent<TutorialStageView>();
        }
        else if(stageType == StageType.CombatStage)
        {
            //gameView = GameObject.Find("CombatStageView").GetComponent<CombatStageView>();
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
        ChangeStage(StageType.LobbyStage);
    }

    public void ChangeStage(StageType stageType)
    {
        StartCoroutine(StageManager.stageInstance.ChangeStageCoroutine(stageType));
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

    public void CombatFinished(int credit, StageType stageType)
    {
        targetStage = stageType;
        gameModel.renewDataCallBack = RenewDataFinished;
        gameModel.RenewUserData(credit);
    }

    public void RenewDataFinished()
    {
        ChangeStage(targetStage);
    }
}
