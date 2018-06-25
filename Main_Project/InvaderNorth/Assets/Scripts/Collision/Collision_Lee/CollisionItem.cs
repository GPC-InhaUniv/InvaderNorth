using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionItem : CollisionForm
{
    protected override void OnTriggerEnter(Collider other)
    {
        //폭탄 충돌 시 폭발 구현
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
                    ItemController.SendItemDelegate(other.gameObject.name);
                    break;

                case "Bomb":
                    ObjectPoolManager.ObjectPools.bombPool.PushToPool(other.gameObject);
                    ItemController.SendItemDelegate(other.gameObject.name);

                    break;
            } 
        }
        else
            return;
    }
}
