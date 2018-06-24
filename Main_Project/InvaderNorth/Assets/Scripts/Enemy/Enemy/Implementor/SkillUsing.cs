using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillUsing
{
    protected float bulletSpeed;
    protected GameObject bullet;

    public abstract void SkillUse(GameObject enemy);

}


public class NoSkill : SkillUsing
{
    public override void SkillUse(GameObject gameObject)
    {
        //Debug.Log("No Skill");
    }
}


public class RoundShot : SkillUsing
{
    private bool canNextMultiShot;

    public RoundShot(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
    }

    public override void SkillUse(GameObject enemy)
    {
        Vector3 spawnPosition = new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z);
        int oneShoting = 25;

        if (canNextMultiShot == false)
        {
            for (int i = 0; i < oneShoting; i++)
            { 
                bullet = ObjectPoolManager.ObjectPools.EnemyBulletPool.PopFromPool();
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0f, 360 * i / oneShoting - 90, 0f));
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -bulletSpeed;


            }
            canNextMultiShot = true;
        }
        else
        {
            for (int i = 0; i < oneShoting; i++)
            {
                bullet = ObjectPoolManager.ObjectPools.EnemyBulletPool.PopFromPool();
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0f, 360 * i / oneShoting + 45 , 0f));
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -bulletSpeed;
            }
            canNextMultiShot = false;
            
        }

        //Debug.Log("MultiShot");
    }
}

public class GuidedShot : SkillUsing
{
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    public GuidedShot(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
    }

    public override void SkillUse(GameObject enemy)
    {
        Vector3 spawnPosition = new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z);
        for (int i = 0; i < 3; i++)
        {
            bullet = ObjectPoolManager.ObjectPools.EnemyBulletPool.PopFromPool();

            if (i == 0)
            {
                bullet.transform.position = spawnPosition;
            }
            else if (i % 2 != 0)
            {
                spawnPosition.x += 1;
                bullet.transform.position = spawnPosition;
            }
            else
            {
                spawnPosition.x -= 2;
                bullet.transform.position = spawnPosition;
            }
            bullet.SetActive(true);
            Vector3 direction = (player.transform.position - bullet.transform.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
        }
        
    }
}


