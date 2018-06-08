using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : CollisionForm
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //오브젝트풀로 반환
        }

        else
            return;
    }
}
