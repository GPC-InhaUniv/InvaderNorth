using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour {

    public int NumberOfNormalBulletCreation;
    private Queue<GameObject> BulletPool;

    void Start()
    {
        BulletPool = new Queue<GameObject>();
        for (int i = 0; i < NumberOfNormalBulletCreation; i++)
        {
            GameObject bullet = Instantiate(Resources.Load("Prefabs/EnemyBullet") as GameObject);
            bullet.name = "EnemyBullet";
            BulletPool.Enqueue(bullet);
            DontDestroyOnLoad(bullet);
        }
    }


    public GameObject PopFromPool()
    {
        return BulletPool.Dequeue();
    }

    public void PushToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.rotation = Quaternion.Euler(Vector3.zero);      
        BulletPool.Enqueue(bullet);
    }

}
