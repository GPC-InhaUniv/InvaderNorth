using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondNamed : Enemy
{

    public SecondNamed(Rigidbody EnemyRigidbody)
    {
        speed = 5;
        bulletSpeed = 10;
        skillBulletSpeed = 15;
        skill = new GuidedShot(skillBulletSpeed);
        baseAttack = new MoreMultiAttack(bulletSpeed);
        moving = new SecondNamedMoving(speed, EnemyRigidbody);
    }
}
