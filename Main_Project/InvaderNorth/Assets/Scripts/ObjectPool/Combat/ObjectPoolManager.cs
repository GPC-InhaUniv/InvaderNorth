using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour {
    public static ObjectPoolManager ObjectPools;
    public PlayerBulletPool PlayerBulletPool;
    public EnemyBulletPool EnemyBulletPool;
    public EnemyPool EnemyPool;
    public CreditPool CreditPool;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (ObjectPools == null)
            ObjectPools = this;
        else
            Destroy(gameObject);

        if (PlayerBulletPool == null)
            PlayerBulletPool = GetComponent<PlayerBulletPool>();

        if (EnemyBulletPool == null)
            EnemyBulletPool = GetComponent<EnemyBulletPool>();

        if (EnemyPool == null)
            EnemyPool = GetComponent<EnemyPool>();

        if (CreditPool == null)
            CreditPool = GetComponent<CreditPool>();

        DontDestroyOnLoad(gameObject);
    }
    
}
