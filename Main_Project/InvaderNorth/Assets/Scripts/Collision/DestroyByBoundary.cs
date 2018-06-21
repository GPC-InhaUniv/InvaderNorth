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
            ItemObjectPool.ItemPoolInstance.shieldPool.PushToPool(other.gameObject);
        }

        else if (other.name == "Bomb")
        {
            ItemObjectPool.ItemPoolInstance.bombPool.PushToPool(other.gameObject);
        }

        else if (other.name =="DarkResource")
        {
            ItemObjectPool.ItemPoolInstance.darkResourcePool.PushToPool(other.gameObject);
        }

        else
        {
            ObjectPool.ObjectPools.EnemyPool.PushToPool(other.gameObject);
        }
    }
}
