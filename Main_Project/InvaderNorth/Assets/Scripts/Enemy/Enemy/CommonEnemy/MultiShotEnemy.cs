using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotEnemy : Enemy
{
    public MultiShotEnemy(Rigidbody EnemyRigidbody)
    {
        speed = 3;
        bulletSpeed = 10;
        skill = new NoSkill();
        baseAttack = new MultiAttack(skillBulletSpeed);
        moving = new Zigzag(speed, EnemyRigidbody);
    }

    
}
