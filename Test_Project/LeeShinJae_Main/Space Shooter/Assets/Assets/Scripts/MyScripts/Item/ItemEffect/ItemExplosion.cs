using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion: ItemEffectType
{
    protected ItemExplosion(Item item)
        :base(item)
    { }
    public override void GetItemDescription()
    {
        Explosion();   
    }

    public void Explosion()
    {

    }

    public override void BeUsed()
    {
        //사용자의 입력을 받아 사용된다.
    }
}
