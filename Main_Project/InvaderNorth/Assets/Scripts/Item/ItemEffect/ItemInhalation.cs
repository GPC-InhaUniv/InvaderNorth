using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//아이템 흡입 효과
public class ItemInhalation : ItemEffectType
{
    private float effectCountiuanceTime;
   
    protected ItemInhalation(Item item)
        :base(item)
    { }
    public override void ApplyTheEffect()
    {
        base.ApplyTheEffect();
        Inhale();
    }

    public void Inhale()
    {

    }

}
