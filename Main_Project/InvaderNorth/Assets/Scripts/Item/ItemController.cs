﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [Header("InventoryImage")]
    [SerializeField]
    private GameObject ShieldImage;
    [SerializeField]
    private GameObject BombImage;
    [SerializeField]
    private GameObject ItemInventoryImage;

    private Bomb bomb;

    private bool haveShieldInInventory;
    private bool haveBombInInventory;

    
    public delegate void SendItemToInventory(string ItemName);
    public static SendItemToInventory SendItemDelegate;

    public delegate void SendUseItem();
    public static SendUseItem SendUseItemDelegate;

    public delegate void SendStartEffect();
    public static SendStartEffect SendStartEffectDelegate;
    
    private void Awake()
    {
        bomb = GetComponent<Bomb>();

        ShieldImage.SetActive(false);
        BombImage.SetActive(false);
        ItemInventoryImage.SetActive(true);

        SendItemDelegate += PushToInventory;
        SendUseItemDelegate += InputItemButton;
        SendStartEffectDelegate += StartTheEffect; 

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            InputItemButton();
        }
    }


    public void PushToInventory(string ItemName)
    {
        if ((haveShieldInInventory == false) || (haveBombInInventory == false))
        {
            switch (ItemName)
            {
                case "Shield":
                    ShieldImage.SetActive(true);
                    haveShieldInInventory = true;
                    ItemInventoryImage.SetActive(false);
                    break;

                case "Boomb":
                    BombImage.SetActive(true);
                    haveBombInInventory = true;
                    ItemInventoryImage.SetActive(false);
                    break;

                default:
                    Debug.Log("Switch문에 적절한 case가 없습니다.");
                    break;
            }
        }

        else
            Debug.Log("이미 소유중인 아이템이 있습니다.");
    }

    public void InputItemButton()
    {
        if (haveBombInInventory == true)
        {
            bomb.LeaveBombFromPlayer();
            BombImage.SetActive(false);
            haveBombInInventory = false;
            ItemInventoryImage.SetActive(true);
        }

        else if (haveShieldInInventory == true)
        {
            ShieldImage.SetActive(false);
            haveShieldInInventory = false;
            ItemInventoryImage.SetActive(true);
        }

        else
            Debug.Log("현재 소유중인 아이템이 없습니다.");
    }

    public void StartTheEffect()
    {
        StartCoroutine(ItemEffectLifeCycle());
    }

    //폭탄의 폭발효과 라이프사이클
    IEnumerator ItemEffectLifeCycle()
    {
        bomb.StartTheEffect();

        yield return new WaitForSeconds(3);

        bomb.StopTheEffect();
    }
}