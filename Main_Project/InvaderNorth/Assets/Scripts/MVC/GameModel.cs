using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class GameModel : MonoBehaviour {

    public delegate void LoadSuccess();
    public LoadSuccess LoadSuccessCallBack;

    public delegate void LoadFail(SignInProcessType loginProcessType);
    public LoadFail LoadFailCallBack;

    public delegate void CreateSuccess();
    public CreateSuccess createSuccessCallBack;
    
    public delegate void CreateFail();
    public CreateSuccess createFailCallBack;

    public void IsLoginDataExist(string id, string password)
    {
        DataManager.Datainstance.GetData(id, password);
    }

    public void LoginSucceeded()
    {
        LoadSuccessCallBack();
    }

    public void LoginFailed(SignInProcessType loginProcessType)
    {
        LoadFailCallBack(loginProcessType);
    }

    public void MakeNewAccount(string id, string password)
    {
        DataManager.Datainstance.CreateNewAccount(id, password);
    }

    public void CreateSucceeded()
    {
        createSuccessCallBack();
    }

    public void CreateFailed()
    {
        createFailCallBack();
    }
}
