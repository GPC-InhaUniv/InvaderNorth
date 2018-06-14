using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpPanel : MonoBehaviour {

    public void ShowMessage(string Message)
    {
        gameObject.GetComponent<Text>().text = Message;
    }
}
