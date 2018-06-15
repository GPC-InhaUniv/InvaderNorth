using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour {

    public Canvas PopUpWindow;
    
    private void Start()
    {
        PopUpWindow.enabled = false;
    }

    public void PopUp()
    {
        PopUpWindow.enabled = true;
    }

    public void Exit()
    {
        PopUpWindow.enabled = false;
    }


}
