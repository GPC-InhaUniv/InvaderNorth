using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionItem : CollisionForm
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("충돌함");
            //itemPool.ReturnItem();//??
        }

        else
            return;
    }
}
