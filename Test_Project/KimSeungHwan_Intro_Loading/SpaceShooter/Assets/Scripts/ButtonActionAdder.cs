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

    // Use this for initialization
    void Start () {
        signInButton.onClick.AddListener(() => gameController.VerifyLoginData(signInIdInputField.text, signInPasswordInputField.text));
        signUpButton.onClick.AddListener(() => gameController.CreateLoginAccount(signUpIdInputField.text, signUpPasswordInputField.text));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
