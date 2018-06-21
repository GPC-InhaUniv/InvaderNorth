using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PopUpType
{
    [Header("Sign Stage UI")]
    SignUpExistingAccount,
    SignUpIdError,
    SignUpSuccess,
    SignInWrongPassword,
    SignInNoAccount,

    
}

public interface IShowable{

    void ShowPopUp(string message, PopUpType popUptype);
}
