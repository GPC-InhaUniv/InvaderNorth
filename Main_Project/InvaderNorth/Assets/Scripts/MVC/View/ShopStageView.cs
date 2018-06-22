using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopStageView : MonoBehaviour, IShowable
{
    [SerializeField]
    private GameObject[] levelImages;

    public void ShowPopUp(PopUpType popUptype)
    {
    }

    public void ShowInformation(GameData gameData)
    {
    }
}