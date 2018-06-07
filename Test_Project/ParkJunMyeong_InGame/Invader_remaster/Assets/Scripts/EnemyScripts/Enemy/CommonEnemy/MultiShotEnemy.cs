using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MultiShotEnemy : Enemy
{
    public MultiShotEnemy()
    {
        Hp = 5;
        Speed = 10;
        Score = 30;
        skillEnable = new MultiShot();
        baseAttackable = new BaseAttack();
        movable = new Moving(Speed);
    }

    
}
