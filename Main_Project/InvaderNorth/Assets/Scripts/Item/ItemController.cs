using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    Explosion,
    Barrier
};

public class ItemController : MonoBehaviour
{
    public EffectType ItemEffectType;

    [Header("Item")]
    //public GameObject ItemObject;
    public GameObject ItemObjectFX;
    public Transform Player;

    [Header("InventoryImage")]
    [SerializeField]
    private GameObject BombImage;
    [SerializeField]
    private GameObject ItemInventoryImage;

    private Item item;
    
    private bool haveBombInInventory;

    
    public delegate void SendItemToInventory(string ItemName);
    public static SendItemToInventory SendItemDelegate;

    public delegate void SendUseItem();
    //public static SendUseItem SendUseItemDelegate;

    public delegate void SendStartEffect();
    public static SendStartEffect SendStartEffectDelegate;
    
    private void Awake()
    {
        
        BombImage.SetActive(false);
        ItemInventoryImage.SetActive(true);

        SendItemDelegate += PushToInventory;
        //SendUseItemDelegate += InputItemButton;
        SendStartEffectDelegate += StartTheEffect;

        GameObject ItemObject = ObjectPoolManager.ObjectPools.bombObjects.PopFromPool();
        GameObject ItemFX = Instantiate(ItemObjectFX);
        Player = GetComponent<Transform>();

        switch(ItemEffectType)
        {
            case EffectType.Explosion:
                item = new Bomb(Player, ItemObject, ItemFX);
                break;
        }
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
        if (haveBombInInventory == false)
        {
            switch (ItemName)
            {
                case "Bomb":
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
            
            item.LeaveItemFromPlayer();
            BombImage.SetActive(false);
            haveBombInInventory = false;
        }
        
        else
            Debug.Log("현재 소유중인 아이템이 없습니다.");
    }

    public void StartTheEffect()
    {
        StartCoroutine(ItemEffectLifeCycle());//스타트코루틴 부재
    }

    //폭탄의 폭발효과 라이프사이클
    IEnumerator ItemEffectLifeCycle()
    {
        item.StartTheEffect();

        yield return new WaitForSeconds(3);

        item.StopTheEffect();
    }
}
