using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemy : CollisionForm
{
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            //if (_CharacterStatus.instance.EnemyHP > 1)
            //{
            //    _CharacterStatus.instance.EnemyHP -= 1;
            //}

            //else
            //{
                //enemy object를 풀로 반환한다.
            //}
        }

        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            //_CharacterStatus.instance.EnemyHP -= 1;
            //폭발 이펙트 불러오기
        }

        else
            return;
    }
}
