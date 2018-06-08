using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : CollisionForm
{
    private _PlayerStatus playerStatus;
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }

        else
            return;
    }
}
