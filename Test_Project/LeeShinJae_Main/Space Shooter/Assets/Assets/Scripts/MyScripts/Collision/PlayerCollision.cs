using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : CollisionForm
{
    
    private new void OnTriggerExit(Collider other)
    {
        //더이상 이 방향으로는 움직이지 못하게 구현
        return;
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            //_PlayerStatus.instance.playerHP -= -1;
            
        }

        if(other.CompareTag("EnemyBullet"))
        {
            //_PlayerStatus.instance.playerHP -= -1;
        }

        if (other.CompareTag("Item"))
        {
            //해당 아이템을 인벤토리에 넣는다.
        }

        else
            return;
    }
}
