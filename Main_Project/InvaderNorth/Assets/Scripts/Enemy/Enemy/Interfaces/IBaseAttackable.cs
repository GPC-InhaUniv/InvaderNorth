using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseAttackable
{
    void Attack(GameObject enemy);

}

public class BaseAttack : MonoBehaviour, IBaseAttackable
{
    GameObject bullet;

    public void Attack(GameObject enemy)
    {
        
        bullet = ObjectPoolManager.PoolManager.EnemyBulletPool.PopFromPool();
        bullet.transform.position = enemy.transform.position;
        bullet.SetActive(true);
        //Debug.Log("BaseAttack");
    }
}

public class MultiAttack : MonoBehaviour, IBaseAttackable
{
    GameObject[] bullets = new GameObject[3];

    public void Attack(GameObject enemy)
    {
        Vector3 spawnPosition = new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z);
        for (int i = 0; i < 3; i++)
        {
            bullets[i] = ObjectPoolManager.PoolManager.EnemyBulletPool.PopFromPool();

            if (i == 0)
            {
                bullets[i].transform.position = spawnPosition;
            }
            else if (i % 2 != 0)
            {
                bullets[i].transform.position = spawnPosition;
                bullets[i].transform.Rotate(new Vector3(0, -1, 0), 8);
            }
            else
            {
                bullets[i].transform.position = spawnPosition;
                bullets[i].transform.Rotate(new Vector3(0, 1, 0), 8);
            }
            bullets[i].SetActive(true);
        }

    }
}

    public class NoBaseAttack : MonoBehaviour, IBaseAttackable
{
    public void Attack(GameObject enemy)
    {
        //Debug.Log("No BaseAttack");
    }
}



