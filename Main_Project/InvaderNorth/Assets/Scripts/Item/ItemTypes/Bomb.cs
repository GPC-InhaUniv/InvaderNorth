using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    //trigger 구체 설정
    public GameObject ExplosionRange;
    
    private void Awake()
    {
        itemName = ItemType.bomb;
        //itemDamage = 10;
        //resourceCount = 0;
        //effectCountiuanceTime = 5f;

        //ExplosionRange.GetComponent<GameObject>();
        //gameObject.AddComponent<ItemExplosion>();
        //gameObject.AddComponent<ItemInvincibility>();
    }

    private void Start()
    {
        //ExplosionRange.SetActive(false);
    }

    public override void ApplyTheEffect()
    {
        
    }

    public void BeUsed()
    {
        //ExplosionRange.SetActive(true);
    }

    public void BeProducedIn()
    {
        //적에따라 다른 아이템 드랍
    }
}
