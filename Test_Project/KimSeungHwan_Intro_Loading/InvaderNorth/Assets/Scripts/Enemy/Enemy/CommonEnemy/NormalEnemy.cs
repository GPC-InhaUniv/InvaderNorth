using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    public NormalEnemy(Rigidbody EnemyRigidbody)
    {
        speed = 5;
        skillEnable = new NoSkill();
        baseAttackable = new BaseAttack();
        movable = new BaseMoving(speed, EnemyRigidbody);
    }

}
