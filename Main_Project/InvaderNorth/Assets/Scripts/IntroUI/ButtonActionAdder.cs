using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActionAdder : MonoBehaviour {

    [SerializeField]
    private Button signInButton;
    [SerializeField]
    private Button signUpButton;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private InputField signInIdInputField;
    [SerializeField]
    private InputField signInPasswordInputField;
    [SerializeField]
    private InputField signUpIdInputField;
    [SerializeField]
    private InputField signUpPasswordInputField;
    
    private void Start () {
        signInButton.onClick.AddListener(() => gameController.VerifyAccountData(signInIdInputField.text, signInPasswordInputField.text));
        signUpButton.onClick.AddListener(() => gameController.CreateAccount(signUpIdInputField.text, signUpPasswordInputField.text));
	}

    
	
}
