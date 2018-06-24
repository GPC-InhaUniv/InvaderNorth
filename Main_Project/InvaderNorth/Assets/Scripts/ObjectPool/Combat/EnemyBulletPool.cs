using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour {

    [SerializeField]
    private int numberOfNormalBulletCreation;
    [SerializeField]
    private GameObject parent;

    private Queue<GameObject> bulletPool;

    void Start()
    {
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < numberOfNormalBulletCreation; i++)
        {
            GameObject bullet = Instantiate(Resources.Load("Prefabs/EnemyBullet") as GameObject);
            bullet.name = "EnemyBullet";
            bulletPool.Enqueue(bullet);
            bullet.transform.parent = parent.transform;         
        }
    }


    public GameObject PopFromPool()
    {
        return bulletPool.Dequeue();
    }

    public void PushToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.rotation = Quaternion.Euler(Vector3.zero);     
        bulletPool.Enqueue(bullet);
    }

}
