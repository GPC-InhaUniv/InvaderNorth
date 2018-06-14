using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour 
{
    public int NumberOfNormalBulletCreation;
    private Queue<GameObject> BulletPool;

    void Start()
    {
        BulletPool = new Queue<GameObject>();
        for (int i = 0; i < NumberOfNormalBulletCreation; i++)
        {
            GameObject bullet = Instantiate(Resources.Load("Prefabs/PlayerBullet") as GameObject);
            bullet.name = "PlayerBullet";
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
        bullet.transform.Rotate(0,0,0);
        BulletPool.Enqueue(bullet);
    }


}
