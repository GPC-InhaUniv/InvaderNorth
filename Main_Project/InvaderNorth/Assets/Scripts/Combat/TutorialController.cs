using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TutorialController : StageController
{
    [Header("Tutorial")]
    [SerializeField]
    private GameObject TutorialSprite;

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
                BossEnemy.SetActive(true);
                hasBoss = true;
            }
            enemy = ObjectPool.ObjectPools.EnemyPool.PopFromPool(0);
            enemy.transform.position = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
            enemy.SetActive(true);
            yield return new WaitForSeconds(2);
        }
        yield return null;
    }

}
