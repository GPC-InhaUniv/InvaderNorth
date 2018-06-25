using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneController : StageController
{
    [SerializeField]
    private Vector3 horizontalMovingEnemySpawnPosition;
    private float time;
    private bool canSpawn = true;
    private int startCoroutineCount;
    private int namedSequenceNum = 0;
    private float waitForSeconds = 2;

    private void Update()
    {
        if(canSpawn)
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

        if (time > 20 && namedSequenceNum == 0)
        {
            namedEnemys[0].SetActive(true);
            namedSequenceNum++;
            canSpawn = false;
        }
        else if (time > 40 && namedSequenceNum == 1)
        {
            namedEnemys[1].SetActive(true);
            namedSequenceNum++;
            canSpawn = false;
        }

        if (namedEnemys[0].activeSelf == false && namedEnemys[1].activeSelf == false)
            canSpawn = true;
    }

    protected override IEnumerator StageProgress()
    {    
        yield return new WaitForSeconds(3);
        time -=3;
        while (true)
        {   
            if(time > 60 && namedSequenceNum == 2)
            {
                bossEnemy.SetActive(true);
                namedSequenceNum++;
                break;
            }
            if (canSpawn)
            {
                enemy = ObjectPoolManager.ObjectPools.EnemyPool.PopFromPool(0);
                if (enemy != null)
                {
                    enemy.transform.position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    enemy.SetActive(true);
                }
            }
            yield return new WaitForSeconds(waitForSeconds);
        }
        yield return null;
    }

    IEnumerator MultiShotEnemySpawn()
    {
        while (true)
        {
            if (namedSequenceNum == 3)
                break;
            if (canSpawn)
            {
                enemy = ObjectPoolManager.ObjectPools.EnemyPool.PopFromPool(1);
                if (enemy != null)
                {
                    enemy.transform.position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    enemy.SetActive(true);
                }
            }
            yield return new WaitForSeconds(waitForSeconds + 3);
        }
        yield return null;
    }

    IEnumerator HorizontalMovingEnemySpawn()
    {
        while (true)
        { 
            if (namedSequenceNum == 3)
                break;
            if (canSpawn)
            {
                if (Random.Range(0, 2) == 0)
                    horizontalMovingEnemySpawnPosition.x = -horizontalMovingEnemySpawnPosition.x;
                enemy = ObjectPoolManager.ObjectPools.EnemyPool.PopFromPool(2);
                if (enemy != null)
                {
                    enemy.transform.position = new Vector3(horizontalMovingEnemySpawnPosition.x, 0, Random.Range(horizontalMovingEnemySpawnPosition.z, 5f));
                    enemy.SetActive(true);
                }
            }
            yield return new WaitForSeconds(waitForSeconds + 1f);
        }
        yield return null;

    }


}
