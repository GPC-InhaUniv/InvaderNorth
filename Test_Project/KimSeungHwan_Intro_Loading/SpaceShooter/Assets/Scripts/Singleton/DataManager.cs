using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Datainstance;
    public GameModel gameModel;
    public GameDataLoader gameDataLoader;
    
    [SerializeField]
    private GameData gameData;

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

    public void DataCallback(GameData gameData)
    {
        if(gameData != null)
        {
            this.gameData = gameData;
            gameModel.LoginSuccessed();

        }
        else
        {
            gameModel.LoginFailed();
        }
    }

    public void MakeNewAccount(string id, string password)
    {

    }

    
}
