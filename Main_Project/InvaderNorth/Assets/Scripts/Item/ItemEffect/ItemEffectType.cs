using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아이템 데코레이터클래스 
public class ItemEffectType : Item
{
    protected Item item;
    
    public override void ApplyTheEffect()
    {
            item.ApplyTheEffect();
    }
}
