using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Datainstance;

    public GameModel gameModel;
    public GameDataLoader gameDataLoader;
    
    public GameData gameData;

	void Awake ()
    {
        Datainstance = this;
        DontDestroyOnLoad(gameObject);
	}

    public void GetData(string id, string password)
    {
        gameDataLoader.loadDataCallback = DataCallback;
        gameDataLoader.LoadGameDataFromDB(id, password);
    }

    public void CreateNewAccount(string id, string password)
    {
        gameDataLoader.createAccountCallBack = CreateAccountCallBack;
        gameDataLoader.MakeNewAccountInDB(id, password);
    }

    public void SetNewData(int credit)
    {
        gameData.credit += credit;
        gameDataLoader.renewDataCallback = RenewDataCallBack;
        gameDataLoader.SetNewDataInDB(gameData.credit);
    }

    public void SetNewPurchaseData(int credit, UpgradeType upgradeType)
    {
        gameData.credit -= credit;
        switch(upgradeType)
        {
            case UpgradeType.Heart:
            {
                gameData.hpLevel++;
                break;
            }
            case UpgradeType.Bullet:
            {
                gameData.bulletLevel++;
                break;
            }
            case UpgradeType.CriticalShot:
            {
                gameData.critLevel++;
                break;
            }
        }
    }

    public void DataCallback(GameData gameData, SignInProcessType loginProcessType)
    {
        if(gameData != null && loginProcessType == SignInProcessType.Success)
        {
            this.gameData = gameData;
            gameModel.LoginSucceeded();
            Debug.Log(gameData.id);
            Debug.Log(gameData.password);
            Debug.Log(gameData.credit);
            Debug.Log(gameData.hpLevel);
            Debug.Log(gameData.critLevel);
            Debug.Log(gameData.bulletLevel);
        }
        else
        {
            gameModel.LoginFailed(loginProcessType);
        }
    }

    public void CreateAccountCallBack(bool IsCreated)
    {
        if(IsCreated == true)
        {
            gameModel.CreateSucceeded();
        }
        else
        {
            gameModel.CreateFailed();
        }
    }
    
    public void RenewDataCallBack()
    {
        gameModel.RenewSucceeded();
    }


}
