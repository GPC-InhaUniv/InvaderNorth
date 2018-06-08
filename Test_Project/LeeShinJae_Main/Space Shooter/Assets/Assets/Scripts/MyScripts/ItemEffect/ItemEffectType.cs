using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아이템 데코레이터클래스 
public class ItemEffectType : Item
{
    protected Item item;

    protected ItemEffectType(Item item)
    {
        this.item = item;
    }
    protected override void GetItemDescription()
    {
        
    }

    protected override void BeUsed()
    {
        
    }

    protected override void BeProducedIn()
    {
        //생산되는 몬스터 타입
    }
}
