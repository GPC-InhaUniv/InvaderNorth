using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void InputButtonCallBack();
public delegate void InputKeyCallBack(KeyActionType keyAction);

public enum KeyActionType
{
    Fire,
    Item,

}

public class InputManager : MonoBehaviour {

    private InputButtonCallBack inputCallBack;
    public static InputManager inputInstance;

    void Awake ()
    {
        inputInstance = this;
        DontDestroyOnLoad(gameObject);
	}
}
