using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour 
{
    [SerializeField]
    private int NumberOfNormalBulletCreation;
    [SerializeField]
    private GameObject Parent;

    private Queue<GameObject> BulletPool;

    void Start()
    {
        BulletPool = new Queue<GameObject>();
        for (int i = 0; i < NumberOfNormalBulletCreation; i++)
        {
            GameObject bullet = Instantiate(Resources.Load("Prefabs/PlayerBullet") as GameObject);
            bullet.name = "PlayerBullet";
            BulletPool.Enqueue(bullet);
            bullet.transform.parent = Parent.transform;
        }
        DontDestroyOnLoad(Parent);
    }


    public GameObject PopFromPool()
    {
        return BulletPool.Dequeue();
    }

    public void PushToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.Rotate(0,0,0);
        BulletPool.Enqueue(gameObject);
    }


}
