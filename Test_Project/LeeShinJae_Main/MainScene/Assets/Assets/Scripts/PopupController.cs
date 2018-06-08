using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour {

    public Canvas popup;
    
    private void Start()
    {
        popup.enabled = false;
    }

    private void ImplementPopup()
    {
        popup.enabled = true;
    }

    private void ExitPopup()
    {
        popup.enabled = false;
    }


}
