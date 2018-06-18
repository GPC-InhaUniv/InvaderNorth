using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TutorialController : StageController
{
    [Header("Tutorial")]
    public GameObject TutorialSprite;

    protected override IEnumerator StagePrograss()
    {
        yield return new WaitForSeconds(3);
        Destroy(TutorialSprite);
        while (true)
        {
            if (IsGameClear)
                break;
            if (scoreTotal >= 60 && hasBoss == false)
            {
                enemy = ObjectPool.ObjectPools.EnemyPool.PopFromPool("TutorialBoss");
                enemy.SetActive(true);
                hasBoss = true;
            }
            enemy = ObjectPool.ObjectPools.EnemyPool.PopFromPool("NormalEnemy");
            enemy.transform.position = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
            enemy.SetActive(true);
            yield return new WaitForSeconds(2);
        }
        yield return null;
    }

}
