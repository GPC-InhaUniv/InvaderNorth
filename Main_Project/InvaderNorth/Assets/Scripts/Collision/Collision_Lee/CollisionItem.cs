using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionItem : CollisionForm
{
    //암흑물질 획득여부
    public bool DarkResourceAcquisition;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "DarkResource")
            {
                ItemObjectPool.ItemPoolInstance.darkResourcePool.PushToPool(gameObject);
                DarkResourceAcquisition = true;
            }
            else
            {
                ItemObjectPool.ItemPoolInstance.bombPool.PushToPool(gameObject);
                ItemObjectPool.ItemPoolInstance.shieldPool.PushToPool(gameObject);
            }
        }

        else
            return;
    }
}
