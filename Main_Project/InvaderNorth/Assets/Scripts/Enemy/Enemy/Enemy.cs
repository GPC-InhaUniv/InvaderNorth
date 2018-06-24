using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy {
    protected SkillUsing skill;
    protected BaseAttack baseAttack;
    protected Moving moving;
    protected float speed;
    protected float bulletSpeed;
    protected float skillBulletSpeed;
    
    public void Attack(GameObject enemy)
    {
        baseAttack.Attack(enemy);
    }

    public void SkillUse(GameObject enemy)
    {
        skill.SkillUse(enemy);
    }

    public void Move(GameObject enemy)
    {
        moving.Move(enemy);
    }



}
