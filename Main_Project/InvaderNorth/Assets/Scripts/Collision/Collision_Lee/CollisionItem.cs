using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionItem : CollisionForm
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "DarkResource")
            {
                ObjectPoolManager.ObjectPools.bombPool.PushToPool(gameObject);
            }
            else if(gameObject.name == "Shield")
            {
                ObjectPoolManager.ObjectPools.shieldPool.PushToPool(gameObject);
                ObjectPoolManager.ObjectPools.CreditPool.PushToPool(gameObject);
            }
        }

        else
            return;
    }
}
