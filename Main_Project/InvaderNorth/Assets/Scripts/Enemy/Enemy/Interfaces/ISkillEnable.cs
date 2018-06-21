using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillEnable
{
    void SkillUse(GameObject enemy);

}


public class NoSkill : ISkillEnable
{
    public void SkillUse(GameObject gameObject)
    {
        //Debug.Log("No Skill");
    }
}


public class RoundShot : ISkillEnable
{
    private bool CanNextMultiShot;
    private GameObject bullet;

    public void SkillUse(GameObject enemy)
    {
        Vector3 spawnPosition = new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z);
        int oneShoting = 25;

        if (CanNextMultiShot == false)
        {
            for (int i = 0; i < oneShoting; i++)
            { 
                bullet = ObjectPool.ObjectPools.EnemyBulletPool.PopFromPool();
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0f, 360 * i / oneShoting - 90, 0f));
                bullet.SetActive(true);        
            }
            CanNextMultiShot = true;
        }
        else
        {
            for (int i = 0; i < oneShoting; i++)
            {
                bullet = ObjectPool.ObjectPools.EnemyBulletPool.PopFromPool();
                bullet.transform.position = spawnPosition;
                bullet.transform.Rotate(new Vector3(0f, 360 * i / oneShoting - 45, 0f));
                bullet.SetActive(true);
                  
            }
            CanNextMultiShot = false;
            
        }

        //Debug.Log("MultiShot");
    }
}

