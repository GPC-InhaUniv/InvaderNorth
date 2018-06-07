using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour {

    public GameObject Bullet;
    public int MaxSize;
    private Queue<GameObject> BulletPool;

    

    void Start()
    {
        BulletPool = new Queue<GameObject>();
        for (int i = 0; i < MaxSize; i++)
        {
            GameObject bullet = Instantiate(Bullet);
            bullet.name = "EnemyBolt";
            BulletPool.Enqueue(bullet);
            DontDestroyOnLoad(bullet);
        }
    }


    public GameObject PopFromPool()
    {
        return BulletPool.Dequeue();
    }

    public void PushToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        BulletPool.Enqueue(gameObject);
    }

}
