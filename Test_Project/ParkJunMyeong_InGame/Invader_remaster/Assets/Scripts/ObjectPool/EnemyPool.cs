using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

    public int NumberOfNormalEnemyCreation;
    public int NumberOfNamedEnemyCreation;
    public int NumberOfBossCreation;
    GameObject tempEnemy;                     // 객체 잠시 담아두기용.
    int stage;                           //스테이지 구분(임시)
    int maxIndex;
    Dictionary<string,GameObject> enemyPool;


    void Start ()
    {
        maxIndex = NumberOfNormalEnemyCreation + NumberOfNamedEnemyCreation + NumberOfBossCreation;
        GameObject normalEnemy;               // 노멀 적 프리팹
        GameObject namedEnemy;                // 네임드 적 프리팹
        GameObject bossEnemy;                 // 보스 적 프리팹
        enemyPool = new Dictionary<string, GameObject>();

        switch (stage)
        {
            case 0 :          //튜토리얼
                normalEnemy = Resources.Load("Prefabs/NormalEnemy") as GameObject;
                bossEnemy = Resources.Load("Prefabs/TutorialBoss") as GameObject;
                for (int i = 1; i <= NumberOfNormalEnemyCreation; i++)
                {
                    enemyPool.Add("NormalEnemy" + i, Instantiate(normalEnemy));
                    tempEnemy = enemyPool["NormalEnemy" + i];
                    tempEnemy.name = "NormalEnemy" + i;
                    DontDestroyOnLoad(tempEnemy);
                }
                for (int i = 1; i <= NumberOfBossCreation; i++)
                {
                    enemyPool.Add("TutorialBoss" + i, Instantiate(bossEnemy));
                    tempEnemy = enemyPool["TutorialBoss" + i];
                    tempEnemy.name = "TutorialBoss" + i;
                    DontDestroyOnLoad(tempEnemy);
                    
                }
                break;

            case 1:           // 첫번째 스테이지
                normalEnemy = Resources.Load("Prefabs/NormalEnemy") as GameObject;
                namedEnemy = Resources.Load("Prefabs/MultiShotEnemy") as GameObject;
                for (int i = 1; i <= NumberOfNormalEnemyCreation; i++)
                {
                    enemyPool.Add("NormalEnemy" + i, Instantiate(normalEnemy));
                    tempEnemy = enemyPool["NormalEnemy" + i];
                    tempEnemy.name = "NormalEnemy" + i;
                    DontDestroyOnLoad(tempEnemy);
                }

                for (int i = 1; i <= NumberOfNamedEnemyCreation; i++)
                {
                    enemyPool.Add("MultiShotEnemy" + i, Instantiate(namedEnemy));
                    tempEnemy = enemyPool["MultiShotEnemy" + i];
                    tempEnemy.name = "MultiShotEnemy" + i;
                    DontDestroyOnLoad(tempEnemy);
                }
                break;
        }
    }

    public GameObject PopFromPool(string EnemyName)
    {
        for (int i = 1; i <= maxIndex; i++)
        {
            if (enemyPool.ContainsKey(EnemyName + i) == true)
            {
                tempEnemy = enemyPool[EnemyName + i];
                enemyPool.Remove(EnemyName + i);
                return tempEnemy;
            }           
        }
        return null;
    }

    public void PushToPool(GameObject Enemy)
    {
        Enemy.SetActive(false);
        enemyPool.Add(Enemy.name, Enemy);
    }

}
