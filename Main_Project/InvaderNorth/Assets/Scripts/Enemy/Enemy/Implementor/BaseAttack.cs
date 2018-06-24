using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack
{
    protected GameObject bullet;
    protected float bulletSpeed;
    public abstract void Attack(GameObject enemy);

}

public class Base : BaseAttack
{
    
    public Base(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
    }

    public override void Attack(GameObject enemy)
    {
        bullet = ObjectPoolManager.ObjectPools.EnemyBulletPool.PopFromPool();
        bullet.transform.position = enemy.transform.position;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * -bulletSpeed;
        //Debug.Log("BaseAttack");
    }
}

public class MultiAttack : BaseAttack
{
    public MultiAttack(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
    }

    public override void Attack(GameObject enemy)
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
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0, -1, 0), 8);
            }
            else
            {
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0, 1, 0), 8);
            }
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -bulletSpeed;
        }

    }
}

public class MoreMultiAttack : BaseAttack
{
    public MoreMultiAttack(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
    }

    public override void Attack(GameObject enemy)
    {
        int angle = 8;
        Vector3 spawnPosition = new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z);
        for (int i = 0; i < 7; i++)
        {
            bullet = ObjectPoolManager.ObjectPools.EnemyBulletPool.PopFromPool();

            if (i == 0)
            {
                bullet.transform.position = spawnPosition;
            }
            else if (i % 2 != 0)
            {
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0, -1, 0), angle);
                
            }
            else
            {
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0, 1, 0), angle);
                angle += 8;
            }
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -bulletSpeed;
        }

    }
}

public class NoBaseAttack : BaseAttack
{
    public override void Attack(GameObject enemy)
    {
        //Debug.Log("No BaseAttack");
    }
}



