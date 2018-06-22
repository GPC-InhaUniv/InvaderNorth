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
                ObjectPool.ObjectPools.bombPool.PushToPool(gameObject);
            }
            else if(gameObject.name == "Shield")
            {
                ObjectPool.ObjectPools.shieldPool.PushToPool(gameObject);
                ObjectPool.ObjectPools.CreditPool.PushToPool(gameObject);
            }
        }

        else
            return;
    }
}
