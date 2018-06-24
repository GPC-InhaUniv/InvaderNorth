using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : StageController
{
    [Header("Tutorial")]
    [SerializeField]
    private GameObject tutorialSprite;            // 초반부터 SetActive가 켜져있음.

    protected override IEnumerator StageProgress()
    {
        yield return new WaitForSeconds(3);
        Destroy(tutorialSprite);   // 요부분이 없애는 것.(한번밖에 안써서 아예 지워버리는 식으로 했습니다.)
        while (true)
        {
            if (IsGameClear || IsGameOver)
                break;
            if (scoreTotal >= 300 && hasBoss == false)
            {
                bossEnemy.SetActive(true);
                hasBoss = true;
            }
            enemy = ObjectPoolManager.ObjectPools.EnemyPool.PopFromPool(0);
            if (enemy != null)
            {
                enemy.transform.position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                enemy.SetActive(true);
            }
            else
            {
                Debug.Log("적 오브젝트 풀 제거됨");
            }
            yield return new WaitForSeconds(2);
        }

        Debug.Log("코루틴 종료");

        yield return null;
    }

}
