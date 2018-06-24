using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    public NormalEnemy(Rigidbody EnemyRigidbody)
    {
        speed = 5;
        bulletSpeed = 10;
        skill = new NoSkill();
        baseAttack = new Base(bulletSpeed);
        moving = new BaseMoving(speed, EnemyRigidbody);
    }

}
