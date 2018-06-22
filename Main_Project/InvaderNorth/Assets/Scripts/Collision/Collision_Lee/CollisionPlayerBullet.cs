using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayerBullet : CollisionForm
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ObjectPoolManager.ObjectPools.PlayerBulletPool.PushToPool(other.gameObject);
        }
        else
            return;
    }
}
