using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FirstBossState
{
    protected GameObject bullet;
    protected float bulletSpeed = 10;
    protected float moveSpeed = 5;

    protected Rigidbody rigidbody;
    public abstract void Move(GameObject boss);
    public abstract void Attack(GameObject boss);
    public abstract void SkillShot(GameObject boss);
}

public class NormalState : FirstBossState
{
    private bool shouldAngleChange ;
    public NormalState(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public override void Attack(GameObject boss)
    {
        float angle;
        float count;
        if (shouldAngleChange == true)
        {
            angle = 0;
            count = 9;
        }
        else
        {
            angle = 5;
            count = 8;
        }
        Vector3 spawnPosition = new Vector3(boss.transform.position.x, 0, boss.transform.position.z);
        for (int i = 0; i < count; i++)
        {
            bullet = ObjectPoolManager.ObjectPools.EnemyBulletPool.PopFromPool();
            if (i % 2 != 0)
            {
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0, -1, 0), angle);
                if(shouldAngleChange == false)
                    angle += 13;
            }
            else
            {
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0, 1, 0), angle);
                if(shouldAngleChange == true)
                    angle += 13;

            }
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -bulletSpeed;
        }
        shouldAngleChange = !shouldAngleChange;
    }

    public override void Move(GameObject boss)
    {
        if (boss.transform.position.z > 10f)
        {
            rigidbody.velocity = boss.transform.forward * (moveSpeed + 3);
        }
        else
            rigidbody.velocity = Vector3.zero;
    }
    public override void SkillShot(GameObject boss)
    {
    }
}

public class AnnoyedState : FirstBossState
{
    private bool isFrist = true;
    private GameObject player;

    public AnnoyedState(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Attack(GameObject boss)
    {

        Vector3 spawnPosition = new Vector3(boss.transform.position.x, 0, boss.transform.position.z);
        bullet = ObjectPoolManager.ObjectPools.EnemyBulletPool.PopFromPool();
        bullet.transform.position = spawnPosition;
        Vector3 direction = (player.transform.position - boss.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * 10;
        bullet.SetActive(true);
    }

    public override void Move(GameObject boss)
    {
            if (isFrist)
            {
                rigidbody.velocity = boss.transform.right * -moveSpeed;
                isFrist = false;
            }
            else if (boss.transform.position.x <= -4.5)
            {
                rigidbody.velocity = boss.transform.right * -moveSpeed;
            }
            else if (boss.transform.position.x >= 4.5)
            {
                rigidbody.velocity = boss.transform.right * moveSpeed;
            }      
    }

    public override void SkillShot(GameObject boss)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5, -2), 0, 18);
        for (int i = 0; i < 4; i ++)
        {
            bullet = ObjectPoolManager.ObjectPools.EnemyBulletPool.PopFromPool();
            bullet.transform.position = spawnPosition;
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -20;
            bullet.SetActive(true);
            spawnPosition.x += 3;
        };
    }
}

public class AngerState : FirstBossState
{
    private bool canNextMultiShot; 

    public AngerState(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public override void Attack(GameObject boss)
    {
        Vector3 spawnPosition = new Vector3(boss.transform.position.x, 0, boss.transform.position.z);
        int oneShoting = 40;

        if (canNextMultiShot == false)
        {
            for (int i = 0; i < oneShoting; i++)
            {
                bullet = ObjectPoolManager.ObjectPools.EnemyBulletPool.PopFromPool();
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0f, 360 * i / oneShoting - 90, 0f));
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -(bulletSpeed) ;


            }
            canNextMultiShot = true;
        }
        else
        {
            for (int i = 0; i < oneShoting; i++)
            {
                bullet = ObjectPoolManager.ObjectPools.EnemyBulletPool.PopFromPool();
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0f, 360 * i / oneShoting - 40, 0f));
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -(bulletSpeed);
            }
            canNextMultiShot = false;

        }
    }

    public override void Move(GameObject boss)
    {
        if (boss.transform.position.x < -0.1)
        {
            rigidbody.velocity = boss.transform.right * - moveSpeed;
        }
        else if (boss.transform.position.x > 0.1)
        {
            rigidbody.velocity = boss.transform.right * moveSpeed;
        }
        else
            rigidbody.velocity = Vector3.zero;
    }

    public override void SkillShot(GameObject boss)
    {
       
    }
}