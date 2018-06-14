using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : CollisionForm
{
    protected new void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boundary"))
            return;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //   if (_CharacterStatus.instance.PlayerHP > 1)
            //   {
            //       _CharacterStatus.instance.PlayerHP -= 1;
            //    }
            //    else
            //    {
            //플레이어 오브젝트를 파괴한다.
            //    }
        }

        if(other.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
            //if (_CharacterStatus.instance.PlayerHP > 1)
            //{
            //    _CharacterStatus.instance.PlayerHP -= 1;
            //}
            //else
            //{
            //    //플레이어 오브젝트를 파괴한다.
            //}
        }

        if (other.CompareTag("Item"))
        {
            // if (플레이어 인벤토리에 빈 공간이 있다면)
            {
                //해당 아이템을 인벤토리에 넣는다.
                //해당 아이템 인벤토리 이미지를 활성화시킨다.
            }
            //else
            {
                //바로 효과가 발현된다.
            }

        }

        else
            return;
    }
}
