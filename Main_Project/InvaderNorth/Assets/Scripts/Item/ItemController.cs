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

    [HideInInspector]
    public GameObject ItemObject;
    private Item item;
    
    private bool haveBombInInventory;

    
    public delegate void SendItemToInventory(string ItemName);
    public static SendItemToInventory SendItemToInventoryDelegate;
    
    public delegate void SendStartEffect(GameObject ExplosionRange, GameObject ItemPosition);
    public static SendStartEffect SendStartEffectDelegate;
    
    private void Awake()
    {
        
        BombImage.SetActive(false);
        ItemInventoryImage.SetActive(true);

        SendItemToInventoryDelegate += PushToInventory;
        SendStartEffectDelegate += StartTheEffect;

        GameObject ItemFX = Instantiate(ItemObjectFX);

        switch(ItemEffectType)
        {
            case EffectType.Explosion:
                item = new Bomb(Player, ItemObject, ItemFX);
                break;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
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
            ItemObject = ObjectPoolManager.ObjectPools.bombObjects.PopFromPool();
            BombImage.SetActive(false);
            haveBombInInventory = false;
            item.LeaveItemFromPlayer(ItemObject);
        }
        
        else
            Debug.Log("현재 소유중인 아이템이 없습니다.");
    }

    public void StartTheEffect(GameObject ExplosionRange, GameObject ItemPosition)
    {
        StartCoroutine(ItemEffectLifeCycle(ExplosionRange, ItemPosition));
    }

    //폭탄의 폭발효과 라이프사이클
    IEnumerator ItemEffectLifeCycle(GameObject ExplosionRange,GameObject ItemPosition)
    {
        item.StartTheEffect(ExplosionRange, ItemPosition);

        yield return new WaitForSeconds(2);

        ///이펙트를 받아와서 반환해야하나
        item.StopTheEffect();
    }
}
