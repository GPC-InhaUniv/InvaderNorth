using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionItem : CollisionForm
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ItemObjectPool.ItemPoolInstance.bombPool.PushToPool(gameObject);
            ItemObjectPool.ItemPoolInstance.shieldPool.PushToPool(gameObject);
            ItemObjectPool.ItemPoolInstance.darkResourcePool.PushToPool(gameObject);
        }

        else
            return;
    }
}
