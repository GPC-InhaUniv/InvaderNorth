using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignStageView : MonoBehaviour, IShowable {

    [Header("SignSceneAttribute")]
    [SerializeField]
    private GameObject signErrorPopUp;
    [SerializeField]
    private Text signErrorMessage;
    [SerializeField]
    private GameObject signSuccessPopUp;
    [SerializeField]
    private Text signSuccessMessage;

    public void ShowPopUp(PopUpType popUpType)
    {
        if(popUpType == PopUpType.SignInNoAccount)
        {
            signErrorMessage.text = "계정이 존재하지 않습니다";
            signErrorPopUp.SetActive(true);
        }
        else if(popUpType == PopUpType.SignInWrongPassword)
        {
            signErrorMessage.text = "비밀번호가 틀렸습니다";
            signErrorPopUp.SetActive(true);
        }
        else if(popUpType == PopUpType.SignUpExistingAccount)
        {
            signErrorMessage.text = "이미 존재하는 계정입니다";
            signErrorPopUp.SetActive(true);
        }
        else if(popUpType == PopUpType.SignUpIdError)
        {
            signErrorMessage.text = "계정 이름은 6글자 이상이어야합니다";
            signErrorPopUp.SetActive(true);
        }
        else if (popUpType == PopUpType.SignUpPasswordError)
        {
            signErrorMessage.text = "계정 비밀번호는 6글자 이상이어야합니다";
            signErrorPopUp.SetActive(true);
        }
        else if(popUpType == PopUpType.SignUpSuccess)
        {
            signSuccessMessage.text = "계정 생성에 성공했습니다";
            signSuccessPopUp.SetActive(true);
        }
        else
        {
            return;
        }
    }
    public void ShowInformation(GameData gameData)
    {

    }

}
