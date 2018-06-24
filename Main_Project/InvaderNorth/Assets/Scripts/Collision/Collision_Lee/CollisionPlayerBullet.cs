using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayerBullet : CollisionForm
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (gameObject.name == "PlayerBullet")
            {
                ObjectPoolManager.ObjectPools.PlayerBulletPool.PushToPool(other.gameObject);
            }

            else if (gameObject.name == "BombObject")
            {
                ItemController.SendStartEffectDelegate();
            }
        }
        
        
            return;
    }
}
