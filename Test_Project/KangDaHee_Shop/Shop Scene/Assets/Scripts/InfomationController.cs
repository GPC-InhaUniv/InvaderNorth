using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfomationController : MonoBehaviour
{
    public GameObject informationBox;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void PopInformation()
    {
        if (informationBox.gameObject.active == false)
        {
            informationBox.SetActive(true);
        }
        else if (informationBox.gameObject.active == true)
        {
            informationBox.SetActive(false);
        }
    }
}