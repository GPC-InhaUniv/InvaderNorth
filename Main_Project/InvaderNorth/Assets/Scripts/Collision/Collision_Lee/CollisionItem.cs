 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionItem : CollisionForm
{
    public bool HaveDarkResource;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (gameObject.name)
            {
                case "DarkResource":
                    ItemObjectPool.ItemPoolInstance.darkResourcePool.PushToPool(gameObject);
                    HaveDarkResource = true;
                    break;

                case "Shield":
                    ItemObjectPool.ItemPoolInstance.shieldPool.PushToPool(gameObject);

                break;

                case "Bomb":
                    ItemObjectPool.ItemPoolInstance.bombPool.PushToPool(gameObject);
                break;

                default:
                    Debug.Log("아이템의 이름이 CollisionItem 스크립트에 없습니다.");
                    break;
               

            }
        }
    }
}
