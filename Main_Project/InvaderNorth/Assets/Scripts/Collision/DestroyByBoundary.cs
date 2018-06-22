using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerBullet")
        {
            ObjectPool.ObjectPools.PlayerBulletPool.PushToPool(other.gameObject);
        }
        else if (other.name == "EnemyBullet")
        {
            ObjectPool.ObjectPools.EnemyBulletPool.PushToPool(other.gameObject);
        }

        else if(other.name == "Shield")
        {
            ObjectPool.ObjectPools.shieldPool.PushToPool(other.gameObject);
        }

        else if (other.name == "Bomb")
        {
            ObjectPool.ObjectPools.bombPool.PushToPool(other.gameObject);
        }
        
        else
        {
            ObjectPool.ObjectPools.EnemyPool.PushToPool(other.gameObject);
        }
    }
}
