using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionItem : CollisionForm
{
    protected override void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Item"))
        {
            
            switch (other.name)
            {
                case "Credit" :
                    ObjectPoolManager.ObjectPools.CreditPool.PushToPool(other.gameObject);
                    StageController.SendCreditDelegate();
                    break;

                case "Shield ":
                    ObjectPoolManager.ObjectPools.shieldPool.PushToPool(other.gameObject);
                    break;
            } 
        }
        else
            return;
    }
}
