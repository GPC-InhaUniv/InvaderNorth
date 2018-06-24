using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingEnemy : Enemy {

    public HorizontalMovingEnemy(Rigidbody EnemyRigidbody)
    {
        speed = 4;
        bulletSpeed = 15;
        skill = new NoSkill();
        baseAttack = new Base(bulletSpeed);
        moving = new HorizontalMoving(speed, EnemyRigidbody);
    }
}
