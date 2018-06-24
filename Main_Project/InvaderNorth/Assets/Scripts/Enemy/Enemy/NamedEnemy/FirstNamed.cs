using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstNamed : Enemy
{

    public FirstNamed(Rigidbody EnemyRigidbody)
    {
        speed = 5;
        bulletSpeed = 10;
        skillBulletSpeed = 5;
        skill = new RoundShot(skillBulletSpeed);
        baseAttack = new NoBaseAttack();
        moving = new FirstNamedMoving(speed, EnemyRigidbody);
    }
}