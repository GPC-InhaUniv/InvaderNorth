using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MultiShotEnemy : Enemy
{
    public MultiShotEnemy(Rigidbody EnemyRigidbody)
    {
        speed = 3;
        skillEnable = new RoundShot();
        baseAttackable = new MultiAttack();
        movable = new NamedMoving(speed, EnemyRigidbody);
    }

    
}
