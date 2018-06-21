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

        else if(other.CompareTag("Item"))
        {
            ItemObjectPool.ItemPoolInstance.shieldPool.PushToPool(other.gameObject);
            ItemObjectPool.ItemPoolInstance.bombPool.PushToPool(other.gameObject);
            ItemObjectPool.ItemPoolInstance.darkResourcePool.PushToPool(other.gameObject);
        }
        
        else
        {
            ObjectPool.ObjectPools.EnemyPool.PushToPool(other.gameObject);
        }
    }
}
