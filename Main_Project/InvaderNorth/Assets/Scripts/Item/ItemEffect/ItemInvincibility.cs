using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//무적효과
public class ItemInvincibility : ItemEffectType
{
    private bool receiveDamage;
    private float effectCountiuanceTime;
    
    public override void ApplyTheEffect()
    {
        base.ApplyTheEffect();
        DontBeAttacked();
    }
    public void DontBeAttacked()
    {

    }
}
