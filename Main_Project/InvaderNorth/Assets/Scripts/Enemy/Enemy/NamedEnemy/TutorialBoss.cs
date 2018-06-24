using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBoss : Enemy
{

    public TutorialBoss(Rigidbody EnemyRigidbody)
    {
        speed = 3;
        bulletSpeed = 10;
        skillBulletSpeed = 20;
        skill = new RoundShot(skillBulletSpeed);
        baseAttack = new MultiAttack(bulletSpeed);
        moving = new NamedMoving(speed, EnemyRigidbody);
    }

}
