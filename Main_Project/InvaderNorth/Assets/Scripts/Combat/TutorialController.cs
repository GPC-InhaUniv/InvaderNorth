using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TutorialController : StageController
{
    [Header("Tutorial")]
    [SerializeField]
    private GameObject tutorialSprite;

    protected override IEnumerator StagePrograss()
    {
        yield return new WaitForSeconds(3);
        Destroy(tutorialSprite);
        while (true)
        {
            if (IsGameClear)
                break;
            if (scoreTotal >= 60 && hasBoss == false)
            {
                bossEnemy.SetActive(true);
                hasBoss = true;
            }
            enemy = ObjectPool.ObjectPools.EnemyPool.PopFromPool(0);
            enemy.transform.position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            enemy.SetActive(true);
            yield return new WaitForSeconds(2);
        }
        yield return null;
    }

}
