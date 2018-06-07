using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject[] Objects;
    public Vector3 SpawnValues;
    GameObject enemy;
    void Start()
    {
        StartCoroutine(tutorialPrograss());
    }

    IEnumerator tutorialPrograss()
    {
        yield return new WaitForSeconds(3);
        Destroy(Objects[0]);
        Destroy(Objects[1]);
        enemy = ObjectPoolManager.PoolManager.EnemyPool.PopFromPool("NormalEnemy");
        enemy.transform.position = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
        enemy.SetActive(true);
        yield return new WaitForSeconds(3);
        enemy = ObjectPoolManager.PoolManager.EnemyPool.PopFromPool("NormalEnemy");
        enemy.transform.position = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
        enemy.SetActive(true);
    }


}
