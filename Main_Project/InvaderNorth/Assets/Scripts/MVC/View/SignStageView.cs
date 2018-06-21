using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignStageView : MonoBehaviour, IShowable {

    [Header("SignSceneAttribute")]
    [SerializeField]
    private GameObject signUpErrorPopUp;
    [SerializeField]
    private Text signUpErrorMessage;
    [SerializeField]
    private GameObject signInErrorPopUp;
    [SerializeField]
    private Text signInErrorMessage;

    public void ShowPopUp(string message, PopUpType popUpType)
    {
        if(popUpType == PopUpType.SignInNoAccount)
        {
            signInErrorMessage.text = message;
            signInErrorPopUp.SetActive(true);
        }
        else if(popUpType == PopUpType.SignInWrongPassword)
        {

        }
        else if(popUpType == PopUpType.SignUpExistingAccount)
        {

        }
        else if(popUpType == PopUpType.SignUpIdError)
        {

        }
        else if(popUpType == PopUpType.SignUpSuccess)
        {

        }
        else
        {
            return;
        }
    }
}
