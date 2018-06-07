using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

    GameObject Enemy;                     // 객체 잠시 담아두기용.
    GameObject NormalEnemy;               // 실제 프리팹이 들어감.

    Dictionary<string,GameObject> enemyPool;


    void Start ()
    {
        enemyPool = new Dictionary<string, GameObject>();
        NormalEnemy = Resources.Load("Prefabs/NormalEnemy") as GameObject;
        for (int i = 1; i <= 10; i++)
        {
            enemyPool.Add("NormalEnemy" + i, Instantiate(NormalEnemy));
            Enemy = enemyPool["NormalEnemy" + i];
            Enemy.name = "NormalEnemy" + i;
            DontDestroyOnLoad(Enemy);
        }
    }

    public GameObject PopFromPool(string EnemyName)
    {
        GameObject Enemy;
        for (int i = 1; i <= 10; i++)
        {
            if (enemyPool.ContainsKey(EnemyName + i) == true)
            {
                Enemy = enemyPool[EnemyName + i];
                enemyPool.Remove(EnemyName + i);
                return Enemy;
            }           
        }
        return null;
    }

    public void PushToPool(GameObject Enemy, string EnemyName)
    {
        Enemy.SetActive(false);
        enemyPool.Add(EnemyName, Enemy);
    }

}
