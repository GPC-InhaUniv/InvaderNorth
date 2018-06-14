using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour {
    public static ObjectPoolManager PoolManager;
    public PlayerBulletPool PlayerBulletPool;
    public EnemyBulletPool EnemyBulletPool;
    public EnemyPool EnemyPool;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (PoolManager == null)
            PoolManager = this;
        else
            Destroy(gameObject);

        if (PlayerBulletPool == null)
            PlayerBulletPool = GetComponent<PlayerBulletPool>();

        if (EnemyBulletPool == null)
            EnemyBulletPool = GetComponent<EnemyBulletPool>();

        if (EnemyPool == null)
            EnemyPool = GetComponent<EnemyPool>();
    }
    
}
