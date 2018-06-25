using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        
        switch(other.name)
        {
            case "Credit":
                return;

            case "PlayerBullet" :
                ObjectPoolManager.ObjectPools.PlayerBulletPool.PushToPool(other.gameObject);
                break;

            case "EnemyBullet" :
                ObjectPoolManager.ObjectPools.EnemyBulletPool.PushToPool(other.gameObject);
                break;

            case "Shield" :
                ObjectPoolManager.ObjectPools.shieldPool.PushToPool(other.gameObject);
                break;
                
            case "Bomb":
                ObjectPoolManager.ObjectPools.bombPool.PushToPool(other.gameObject);
                break;

            case "BombObject":
                ObjectPoolManager.ObjectPools.bombObjects.PushToPool(other.gameObject);
                break;

            default :
                ObjectPoolManager.ObjectPools.EnemyPool.PushToPool(other.gameObject);
                break;
        }
        /*if (other.name == "PlayerBullet")
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
        }*/
    }
}
