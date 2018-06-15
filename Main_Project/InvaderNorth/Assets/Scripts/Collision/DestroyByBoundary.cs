using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerBullet")
        {
            ObjectPoolManager.PoolManager.PlayerBulletPool.PushToPool(other.gameObject);
        }
        else if (other.name == "EnemyBullet")
        {
            ObjectPoolManager.PoolManager.EnemyBulletPool.PushToPool(other.gameObject);
        }
        else
            ObjectPoolManager.PoolManager.EnemyPool.PushToPool(other.gameObject);
    }
}
