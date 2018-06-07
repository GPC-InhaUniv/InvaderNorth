using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour {
    public static ObjectPoolManager PoolManager;
    public PlayerBulletPool PlayerBullets;
    public EnemyBulletPool EnemyBullets;
    public EnemyPool EnemyPool;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (PoolManager == null)
            PoolManager = this;
        else
            Destroy(gameObject);

        if (PlayerBullets == null)
            PlayerBullets = GetComponent<PlayerBulletPool>();


        if (EnemyBullets == null)
            EnemyBullets = GetComponent<EnemyBulletPool>();

        if (EnemyPool == null)
            EnemyPool = GetComponent<EnemyPool>();
    }

    
    

    
}
