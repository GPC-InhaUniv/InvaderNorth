using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkResourcePool : MonoBehaviour
{
    public GameObject itemObject;
    public GameObject Parent;

    Queue<GameObject> itemPool;
    public int MaxNumberOfDarkResource;

    private void Start()
    {
        MaxNumberOfDarkResource = 10;
        itemPool = new Queue<GameObject>();
        CreatBombPool();
    }

    private void CreatBombPool()
    {
        for (int i = 1; i <= MaxNumberOfDarkResource; i++)
        {
            itemObject = Instantiate(itemObject);
            itemObject.name = "DarkResource";
            itemObject.SetActive(false);
            itemPool.Enqueue(itemObject);
            itemObject.transform.parent = Parent.transform;
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