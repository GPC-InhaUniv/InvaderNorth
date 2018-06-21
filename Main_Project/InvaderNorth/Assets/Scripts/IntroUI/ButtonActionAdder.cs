using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActionAdder : MonoBehaviour {

    public Button signInButton;
    public Button signUpButton;
    public GameController gameController;
    public InputField signInIdInputField;
    public InputField signInPasswordInputField;
    public InputField signUpIdInputField;
    public InputField signUpPasswordInputField;
    
    private void Start () {
        signInButton.onClick.AddListener(() => gameController.VerifyAccountData(signInIdInputField.text, signInPasswordInputField.text));
        signUpButton.onClick.AddListener(() => gameController.CreateAccount(signUpIdInputField.text, signUpPasswordInputField.text));
	}

    
	
}
