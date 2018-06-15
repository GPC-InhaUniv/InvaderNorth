using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Datainstance;
    public GameModel gameModel;
    public GameDataLoader gameDataLoader;
    
    //[SerializeField]
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

    public void DataCallback(GameData gameData, LoginProcessType loginProcessType)
    {
        if(gameData != null && loginProcessType == LoginProcessType.Success)
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

    public void CreateAccountCallBack()
    {
        gameModel.CreateSucceeded();
    }
}
