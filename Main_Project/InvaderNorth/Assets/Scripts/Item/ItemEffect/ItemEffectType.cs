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

    public override void ApplyTheEffect()
    {
        if (item != null)
        {
            item.ApplyTheEffect();
        }
    }
}
