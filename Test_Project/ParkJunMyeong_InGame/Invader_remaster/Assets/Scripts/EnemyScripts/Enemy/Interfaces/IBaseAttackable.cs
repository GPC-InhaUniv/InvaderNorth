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
        
        bullet = ObjectPoolManager.PoolManager.EnemyBullets.PopFromPool();
        bullet.transform.position = enemy.transform.position;
        bullet.SetActive(true);
        Debug.Log("BaseAttack");
    }
}

public class NoBaseAttack : MonoBehaviour, IBaseAttackable
{
    public void Attack(GameObject enemy)
    {
        Debug.Log("No BaseAttack");
    }
}



