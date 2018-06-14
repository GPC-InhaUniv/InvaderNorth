using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour {

    public Canvas popUpWindow;
    
    private void Start()
    {
        popUpWindow.enabled = false;
    }

    public void PopUp()
    {
        popUpWindow.enabled = true;
    }

    public void Exit()
    {
        popUpWindow.enabled = false;
    }


}
