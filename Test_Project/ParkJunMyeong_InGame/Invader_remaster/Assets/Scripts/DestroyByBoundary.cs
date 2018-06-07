using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Bolt")
        {
            ObjectPoolManager.PoolManager.PlayerBullets.PushToPool(other.gameObject);
        }
        else if (other.name == "EnemyBolt")
        {
            ObjectPoolManager.PoolManager.EnemyBullets.PushToPool(other.gameObject);
        }
        else
            Destroy(other.gameObject);
    }
}
