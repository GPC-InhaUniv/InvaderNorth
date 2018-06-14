using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemyBolt : CollisionForm
{
   
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            //오브젝트풀로 반환된다.
            //폭발 이펙트를 불러온다.
        }
        else
            return;
    }
}
