using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class GameModel : MonoBehaviour {

    public delegate void LoadSuccess(bool isLoaded);
    public LoadSuccess LoadSuccessCallBack;

	public void IsLoginDataExist(string id, string password)
    {
        DataManager.Datainstance.GetData(id, password);
    }

    public void LoginSuccessed()
    {
        LoadSuccessCallBack(true);
    }

    public void LoginFailed()
    {
        LoadSuccessCallBack(false);
    }

    public void MakeNewAccount(string id, string password)
    {
        DataManager.Datainstance.MakeNewAccount(id, password);
    }
}
