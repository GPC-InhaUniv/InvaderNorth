using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour {

    public GameObject PopUpPanel;
    public Text PopUpPanelText;

    public void ShowPopUp(string message)
    {
        PopUpPanel.SetActive(true);
        PopUpPanelText.text = message;
    }
}
