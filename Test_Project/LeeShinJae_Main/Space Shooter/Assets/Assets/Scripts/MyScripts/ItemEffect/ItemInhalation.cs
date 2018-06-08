using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//아이템 흡입 효과
public class ItemInhalation : ItemEffectType
{
    protected ItemInhalation(Item item)
        :base(item)
    { }
    protected override void GetItemDescription()
    {
        //비행기의 아이템 흡입속성을 true로 바꾼다(일정시간동안?)
    }

    protected override void BeUsed()
    {
        // playerShip에 접촉한 순간 사용된다.
    }

}
