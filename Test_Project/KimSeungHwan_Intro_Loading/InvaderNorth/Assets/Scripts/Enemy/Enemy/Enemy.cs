using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy {
    protected ISkillEnable skillEnable;
    protected IBaseAttackable baseAttackable;
    protected IMovable movable;
    protected float speed;

    public void Attack(GameObject enemy)
    {
        baseAttackable.Attack(enemy);
    }

    public void SkillUse(GameObject enemy)
    {
        skillEnable.SkillUse(enemy);
    }

    public void Move(GameObject enemy)
    {
        movable.Move(enemy);
    }



}
