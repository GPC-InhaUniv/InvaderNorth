using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosionFXPool : MonoBehaviour {

    [SerializeField]
    private GameObject itemObject;
    [SerializeField]
    private GameObject Parent;

    Queue<GameObject> itemPool;
    public int MaxNumberOfBomb;

    private void Start()
    {
        MaxNumberOfBomb = 2;
        itemPool = new Queue<GameObject>();
        CreatBombPool();
    }

    private void CreatBombPool()
    {
        for (int i = 1; i <= MaxNumberOfBomb; i++)
        {
            GameObject item = Instantiate(itemObject);
            item.name = "BombExplosionFX";
            item.SetActive(false);
            itemPool.Enqueue(item);
            item.transform.parent = Parent.transform;
        }
        DontDestroyOnLoad(Parent);
    }

    public GameObject PopFromPool()
    {
        return itemPool.Dequeue();
    }

    public void PushToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        itemPool.Enqueue(gameObject);
    }
}
