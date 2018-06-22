using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerBullet")
        {
            ObjectPoolManager.ObjectPools.PlayerBulletPool.PushToPool(other.gameObject);
        }
        else if (other.name == "EnemyBullet")
        {
            ObjectPoolManager.ObjectPools.EnemyBulletPool.PushToPool(other.gameObject);
        }

        else if(other.name == "Shield")
        {
            ObjectPoolManager.ObjectPools.shieldPool.PushToPool(other.gameObject);
        }

        else if (other.name == "Bomb")
        {
            ObjectPoolManager.ObjectPools.bombPool.PushToPool(other.gameObject);
        }
        
        else
        {
            ObjectPoolManager.ObjectPools.EnemyPool.PushToPool(other.gameObject);
        }
    }
}
