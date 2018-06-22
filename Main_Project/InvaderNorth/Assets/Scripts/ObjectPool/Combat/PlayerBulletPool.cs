using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour 
{
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
            GameObject bullet = Instantiate(Resources.Load("Prefabs/PlayerBullet") as GameObject);
            bullet.name = "PlayerBullet";
            bulletPool.Enqueue(bullet);
            bullet.transform.parent = parent.transform;
        }
    }


    public GameObject PopFromPool()
    {
        return bulletPool.Dequeue();
    }

    public void PushToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.Rotate(0,0,0);
        bulletPool.Enqueue(gameObject);
    }


}
