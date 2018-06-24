using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FirstBossState
{
    protected GameObject bullet;
    protected float speed = 3;
    protected Rigidbody rigidbody;
    public abstract void Move(GameObject boss);
    public abstract void Attack(GameObject boss);
    public abstract void SkillMove(GameObject boss);
    public abstract void SkillShot(GameObject boss);
}

public class NormalState : FirstBossState
{
    public NormalState(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public override void Attack(GameObject boss)
    {
        if (boss.transform.position.z > 11)
        {
            rigidbody.velocity = boss.transform.forward * speed;
        }
        else
            rigidbody.velocity = Vector3.zero;

        bullet = ObjectPoolManager.ObjectPools.EnemyBulletPool.PopFromPool();
        bullet.transform.position = boss.transform.position;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * -speed;
        Debug.Log("NormalState Attack");
    }

    public override void Move(GameObject boss)
    {
        
    }

    public override void SkillMove(GameObject boss)
    {

    }

    public override void SkillShot(GameObject boss)
    {

    }
}

public class AnnoyedState : FirstBossState
{
    public AnnoyedState(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public override void Attack(GameObject boss)
    {

        Debug.Log("AnnoyedState Attack");
    }

    public override void Move(GameObject boss)
    {
        Debug.Log("AnnoyedState Move");
    }

    public override void SkillMove(GameObject boss)
    {

    }

    public override void SkillShot(GameObject boss)
    {

    }
}

public class AngerState : FirstBossState
{
    public AngerState(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public override void Attack(GameObject boss)
    {

        Debug.Log("AngerState Attack");
    }

    public override void Move(GameObject boss)
    {
        Debug.Log("AngerState Move");
    }

    public override void SkillMove(GameObject boss)
    {

    }

    public override void SkillShot(GameObject boss)
    {

    }
}