using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneController : StageController
{
    [SerializeField]
    private Transform HorizontalMovingEnemySpawnPosition;
    private float time;
    private int startCoroutineCount;
    private float waitForSeconds = 2;
    private void Update()
    {
        Debug.Log(time);
        time += Time.deltaTime;
        if(time > 10 && startCoroutineCount == 0)
        {
            StartCoroutine(MultiShotEnemySpawn());
            startCoroutineCount++;
        }
        else if(time > 20 && startCoroutineCount == 1)
        {
            StartCoroutine(HorizontalMovingEnemySpawn());
            startCoroutineCount++;
        }
        
    }


    protected override IEnumerator StageProgress()
    {
        yield return new WaitForSeconds(3);
        time -=3;
        while (true)
        {
            enemy = ObjectPoolManager.ObjectPools.EnemyPool.PopFromPool(0);
            if (enemy != null)
            {
                enemy.transform.position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(waitForSeconds);
        }
        yield return null;
    }

    IEnumerator MultiShotEnemySpawn()
    {
        while(true)
        {
            enemy = ObjectPoolManager.ObjectPools.EnemyPool.PopFromPool(1);
            if (enemy != null)
            {
                enemy.transform.position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(waitForSeconds + 3 );
        }
        yield return null;
    }

    IEnumerator HorizontalMovingEnemySpawn()
    {
        while (true)
        {
            enemy = ObjectPoolManager.ObjectPools.EnemyPool.PopFromPool(2);
            if (enemy != null)
            {
                enemy.transform.position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(waitForSeconds + 1.5f);
        }
        yield return null;
    }
    



}
