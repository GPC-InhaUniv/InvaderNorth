using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayerBolt : CollisionForm
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //오브젝트풀로 반환하기
        }
        else
            return;
    }
}
