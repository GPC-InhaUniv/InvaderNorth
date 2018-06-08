using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion: ItemEffectType
{
    protected ItemExplosion(Item item)
        :base(item)
    { }
    protected override void GetItemDescription()
    {
        //광범위하게 콜리젼)을 뿌린다.
    }

    protected override void BeUsed()
    {
        //사용자의 입력을 받아 사용된다.
    }
}
