using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OneStageBossState : MonoBehaviour
{
    public abstract void Move();
    public abstract void Attack(GameObject boss);
    protected GameObject normalBullet;
    protected GameObject skillBullet;
}

public class NormalState : OneStageBossState
{
    public NormalState(GameObject normalBullet, GameObject skillBullet)
    {
        this.normalBullet = normalBullet;
        this.skillBullet = skillBullet;
    }

    public override void Attack(GameObject boss)
    {
        Instantiate(normalBullet, boss.transform.position, Quaternion.identity);
        Debug.Log("NormalState Attack");
    }

    public override void Move()
    {
        Debug.Log("NormalState Move");
    }
}

public class AnnoyedState : OneStageBossState
{
    public AnnoyedState(GameObject normalBullet, GameObject skillBullet)
    {
        this.normalBullet = normalBullet;
        this.skillBullet = skillBullet;
    }

    public override void Attack(GameObject boss)
    {
        Vector3 spawnPosition = new Vector3(boss.transform.position.x, 0, boss.transform.position.z);
        Instantiate(normalBullet, spawnPosition, Quaternion.identity);
        spawnPosition.x -= 0.5f;
        Instantiate(normalBullet, spawnPosition, Quaternion.identity);
        spawnPosition.x += 1f;
        Instantiate(normalBullet, spawnPosition, Quaternion.identity);
        Debug.Log("AnnoyedState Attack");
    }

    public override void Move()
    {
        Debug.Log("AnnoyedState Move");
    }
}

public class AngerState : OneStageBossState
{
    public AngerState(GameObject normalBullet, GameObject skillBullet)
    {
        this.normalBullet = normalBullet;
        this.skillBullet = skillBullet;
    }

    public override void Attack(GameObject boss)
    {
        Vector3 spawnPosition = new Vector3(boss.transform.position.x, 0, boss.transform.position.z);
        Instantiate(normalBullet, spawnPosition, Quaternion.identity);
        spawnPosition.x -= 0.5f;
        Instantiate(normalBullet, spawnPosition, Quaternion.identity);
        spawnPosition.x -= 0.5f;
        Instantiate(normalBullet, spawnPosition, Quaternion.identity);
        spawnPosition.x += 1.5f;
        Instantiate(normalBullet, spawnPosition, Quaternion.identity);
        spawnPosition.x += 0.5f;
        Instantiate(normalBullet, spawnPosition, Quaternion.identity);
        Debug.Log("AngerState Attack");
    }

    public override void Move()
    {
        Debug.Log("AngerState Move");
    }
}