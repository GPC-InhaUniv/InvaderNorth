using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//무적효과
public class ItemInvincibility : ItemEffectType
{
    protected ItemInvincibility(Item item)
        :base(item)
    { }
    public override void ApplyTheEffect()
    {
        //플레이어가 무적이 된다.
        //플레이어의 OntirggerEnter속성을 false로 바꾼다 ==> 아이템이 안먹어질 가능성이 있다.
        //==> Player/enemy, enemyBullet 충돌만 off시킨다.

    }

    public override void BeUsed()
    {
        //플레이어의 입력을 받아 사용된다.
    }

    public void DontBeAttacked()
    {

    }
}
