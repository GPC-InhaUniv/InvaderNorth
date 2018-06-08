using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public string poolEnemyName = string.Empty;
    public GameObject prefab = null;
    public int poolCount = 0;

    [SerializeField]
    private List<GameObject> poolList = new List<GameObject>();

    public void Initialize(Transform parent = null)
    {
        for(int ix = 0; ix < poolCount; ++ix)
        {
            poolList.Add(CreateEnemy(parent));
        }
    }

    public void PushToPool(GameObject enemy, Transform parent=null)
    {
        enemy.transform.SetParent(parent);
        enemy.SetActive(false);
        poolList.Add(enemy);
    }

    public GameObject PopFromPool(Transform parent = null)
    {
        if(poolList.Count == 0)
        {
            poolList.Add(CreateEnemy(parent));
        }

        GameObject enemy = poolList[0];
        poolList.RemoveAt(0);

        return enemy;
    }
    public GameObject CreateEnemy(Transform parent = null)
    {
        GameObject enemy = Object.Instantiate(prefab) as GameObject;
        enemy.name = poolEnemyName;
        enemy.transform.SetParent(parent);
        enemy.SetActive(false);

        return enemy;
    }


}
