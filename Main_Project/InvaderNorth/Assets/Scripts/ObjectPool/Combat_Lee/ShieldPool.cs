using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPool : MonoBehaviour
{
    public GameObject itemObject;
    public GameObject Parent;

    Queue<GameObject> itemPool;
    private int MaxNumberOfShield;

    private void Start()
    {
        MaxNumberOfShield = 3;
        itemPool = new Queue<GameObject>();
        CreatBombPool();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            PopFromPool();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            PushToPool();
        }
    }
    private void CreatBombPool()
    {
        for (int i = 1; i <= MaxNumberOfShield; i++)
        {
            GameObject item = Instantiate(itemObject);
            item.name = "Shield";
            itemPool.Enqueue(itemObject);
            item.transform.parent = Parent.transform;
        }
        DontDestroyOnLoad(Parent);
    }

    public GameObject PopFromPool()
    {
        return itemPool.Dequeue();
    }

    public void PushToPool()
    {
        gameObject.SetActive(false);
        itemPool.Enqueue(gameObject);
    }
}
