using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void InputButtonCallBack(string id, string password, InputType inputType);
public delegate void InputKeyCallBack(KeyActionType keyAction);

public enum KeyActionType
{

}

public enum InputType
{
    signIn,
    signUp,

}

public class InputManager : MonoBehaviour {

    private InputButtonCallBack inputCallBack;
    public static InputManager inputInstance;

    void Awake ()
    {
        inputInstance = this;
        DontDestroyOnLoad(gameObject);
	}

    public void Register(InputButtonCallBack inputCallBack)
    {
        inputInstance.inputCallBack = inputCallBack; 
    }

    public void LogIn(string id, string password, InputType inputType)
    {
        StageManager.stageInstance.ChangeStage();
    }
}
