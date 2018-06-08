using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    public List<PooledObject> objectPool = new List<PooledObject>();

    private void Awake()
    {
        for(int i = 0; i<objectPool.Count; ++i)
        {
            objectPool[i].Initialize(transform);
        }
    }
    public bool PushToPool(string enemyName, GameObject enemy, Transform parent = null)
    {
        PooledObject pool = GetPoolEnemy(enemyName);
        if(pool == null)
        {
            return false;
        }
        pool.PushToPool(enemy, parent == null ? transform : parent);
        return true;
    }

    public GameObject PopFromPool(string enemyName, Transform parent = null)
    {
        PooledObject pool = GetPoolEnemy(enemyName);
        if (pool == null)
            return null;

        return pool.PopFromPool(parent);
    }

    PooledObject GetPoolEnemy(string enemyName)
    {
        for(int i= 0; i<objectPool.Count; ++i)
        {
            if (objectPool[i].poolEnemyName.Equals(enemyName))
                return objectPool[i];
        }

        Debug.LogWarning("풀 리스트에 매치되는 내용이 없습니다.");
        return null;
    }
}
