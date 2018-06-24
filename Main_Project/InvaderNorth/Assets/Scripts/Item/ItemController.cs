using System.Collections;
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

    public Bomb bomb;

    private bool haveShieldInInventory;
    private bool haveBombInInventory;

    
    public delegate void SendItemToInventory(string ItemName);
    public static SendItemToInventory SendItemDelegate;

    public delegate void SendUseItem();
    public static SendUseItem SendUseItemDelegate;
    
    
    private void Awake()
    {
        bomb = GetComponent<Bomb>();

        ShieldImage.SetActive(false);
        BombImage.SetActive(false);

        SendItemDelegate += PushToInventory;
        SendUseItemDelegate += InputItemButton;

        StartCoroutine(ItemEffectLifeCycle());

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
                    break;

                case "Boomb":
                    BombImage.SetActive(true);
                    haveBombInInventory = true;
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
            BombImage.SetActive(false);
            haveBombInInventory = false;
        }

        else if (haveShieldInInventory == true)
        {
            ShieldImage.SetActive(false);
            haveShieldInInventory = false;
        }

        else
            Debug.Log("현재 소유중인 아이템이 없습니다.");
    }
    
    //IEnumerator ItemEffectLifeCycle()
    //{
    //    //*******************************
    //    bomb.ExertAnEffect();

    //    yield return new WaitForSeconds(2);

    //    bomb.StopTheEffect();
    //}
    
    
}
