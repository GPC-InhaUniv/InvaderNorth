using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour {

    [SerializeField]
    private GameObject MessagePopUpPanel;
    [SerializeField]
    private Text MessagePopUpPanelText;
    [SerializeField]
    private Text SignUpErrorMessageText;
    [SerializeField]
    private Text SignUpSuccessMessageText;

    public void ShowPopUp(string message)
    {
        MessagePopUpPanel.SetActive(true);
        MessagePopUpPanelText.text = message;
    }

    public void ShowSignUpSuccessMessage()
    {
        SignUpSuccessMessageText.gameObject.SetActive(true);
    }

    public void ShowSignUpErrorMessage()
    {
        SignUpErrorMessageText.gameObject.SetActive(true);
    }

    public void HideSignUpErrorMessage()
    {
        SignUpErrorMessageText.gameObject.SetActive(false);
    }
}
