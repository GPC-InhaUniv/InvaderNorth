﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPool : MonoBehaviour
{
    public GameObject itemObject;
    public GameObject Parent;

    Queue<GameObject> itemPool;
    public int MaxNumberOfShield;

    private void Start()
    {
        MaxNumberOfShield = 3;
        itemPool = new Queue<GameObject>();
        CreatBombPool();
    }
  
    private void CreatBombPool()
    {
        for (int i = 1; i <= MaxNumberOfShield; i++)
        {
            GameObject item = Instantiate(itemObject);
            item.name = "Shield";
            itemObject.SetActive(false);
            itemPool.Enqueue(itemObject);
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