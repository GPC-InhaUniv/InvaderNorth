using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TutorialController : StageController
{
    [Header("Tutorial")]
    [SerializeField]
    private GameObject tutorialSprite;            // 초반부터 SetActive가 켜져있음.

    protected override IEnumerator StagePrograss()
    {
        yield return new WaitForSeconds(3);
        Destroy(tutorialSprite);   // 요부분이 없애는 것.(한번밖에 안써서 아예 지워버리는 식으로 했습니다.)
        GameObject[] gameObjects = new GameObject[5] ;
        for(int i = 0; i < 5; i ++)
        {
            gameObjects[i] = ObjectPoolManager.ObjectPools.CreditPool.PopFromPool();
            gameObjects[i].SetActive(true);
        }
        while (true)
        {
            if (IsGameClear)
                break;
            if (scoreTotal >= 60 && hasBoss == false)
            {
                bossEnemy.SetActive(true);
                hasBoss = true;
            }
            enemy = ObjectPoolManager.ObjectPools.EnemyPool.PopFromPool(0);
            enemy.transform.position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            enemy.SetActive(true);
            yield return new WaitForSeconds(2);
        }
        yield return null;
    }

}
