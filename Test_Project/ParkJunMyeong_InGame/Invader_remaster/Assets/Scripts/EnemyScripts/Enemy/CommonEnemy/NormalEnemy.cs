using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{


    public NormalEnemy()
    {
        Hp = 1;
        Speed = 10;
        Score = 10;
        skillEnable = new NoSkill();
        baseAttackable = new BaseAttack();
        movable = new Moving(Speed);
    }

}
