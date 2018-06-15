using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion: ItemEffectType
{
    private float itemDamage;

    private void Awake()
    {
        itemDamage = 10;
    }

    protected ItemExplosion(Item item)
        :base(item)
    { }

    public override void ApplyTheEffect()
    {
        base.ApplyTheEffect();
        Explosion();
    }

    public void Explosion()
    {

    }

}
