using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillEnable
{
    void SkillUse(GameObject enemy);

}


public class NoSkill : MonoBehaviour, ISkillEnable
{
    public void SkillUse(GameObject gameObject)
    {
        Debug.Log("No Skill");
    }
}


public class MultiShot : MonoBehaviour, ISkillEnable
{
    GameObject[] bullets = new GameObject[3];

    public void SkillUse(GameObject enemy)
    {
        Vector3 spawnPosition = new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z);
        float gap_x = 0;
        for (int i = 0; i < 3; i++)
        {
            bullets[i] = ObjectPoolManager.PoolManager.EnemyBullets.PopFromPool();
            if (i == 0)
            {
                bullets[i].transform.position = spawnPosition;
            }
            else if (i % 2 != 0)
            {
                gap_x += 0.5f;
                spawnPosition.x += gap_x;
                bullets[i].transform.position = spawnPosition;
            }
            else
            {
                gap_x += 0.5f;
                spawnPosition.x -= gap_x;
                bullets[i].transform.position = spawnPosition;
            }
            bullets[i].SetActive(true);
        }
        Debug.Log("MultiShot");
    }
}