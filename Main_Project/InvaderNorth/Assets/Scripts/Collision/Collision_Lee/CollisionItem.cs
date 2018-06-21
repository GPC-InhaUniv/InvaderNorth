using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionItem : CollisionForm
{
    public bool isReturnDarkResource;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "DarkResource")
            {
                ItemObjectPool.ItemPoolInstance.bombPool.PushToPool(gameObject);
                isReturnDarkResource = true;
            }
            else
            {
                ItemObjectPool.ItemPoolInstance.shieldPool.PushToPool(gameObject);
                ItemObjectPool.ItemPoolInstance.darkResourcePool.PushToPool(gameObject);
            }
        }

        else
            return;
    }
}
