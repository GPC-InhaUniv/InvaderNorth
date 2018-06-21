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
    
    public void SetGameView()
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
            gameView.ShowPopUp("계정이 존재하지 않습니다", PopUpType.SignInNoAccount);
        }
        if (loginProcessType == SignInProcessType.WrongPassword)
        {
            gameView.ShowPopUp("비밀번호가 틀렸습니다", PopUpType.SignInWrongPassword);
        }
    }

    public void CreateAccount(string id, string password)
    {
        if(id != null && id.Length > 6)
        {
            gameModel.createSuccessCallBack = AccountCreated;
            gameModel.createFailCallBack = AccountNotCreadted;
            gameModel.MakeNewAccount(id, password);
        }
        else
        {
            gameView.ShowPopUp("계정 ID는 6자 이상이어야 합니다", PopUpType.SignUpIdError);
        }
    }

    public void AccountCreated()
    {
        gameView.ShowPopUp("계정이 생성되었습니다.", PopUpType.SignUpSuccess);
    }

    public void AccountNotCreadted()
    {
        gameView.ShowPopUp("이미 존재하는 계정입니다.", PopUpType.SignUpIdError);
    }
}
