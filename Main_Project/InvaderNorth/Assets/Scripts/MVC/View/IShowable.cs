using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PopUpType
{
    [Header("Sign Stage UI")]
    SignUpExistingAccount,
    SignUpIdError,
    SignUpPasswordError,
    SignUpSuccess,
    SignInWrongPassword,
    SignInNoAccount,
}

public interface IShowable{

    void ShowPopUp(PopUpType popUptype);
    void ShowInformation(GameData gameData);
}
