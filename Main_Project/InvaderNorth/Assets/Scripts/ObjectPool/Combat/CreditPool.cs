﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPool : MonoBehaviour {

    [SerializeField]
    private int numberOfSpaceResourceCreation;
    [SerializeField]
    private GameObject spaceResource;
    [SerializeField]
    private GameObject parent;

    private Queue<GameObject> spaceResourcePool;

    void Start()
    {
        spaceResourcePool = new Queue<GameObject>();
        for (int i = 0; i < numberOfSpaceResourceCreation; i++)
        {
            GameObject temp = Instantiate(spaceResource);
            temp.name = "Credit";
            spaceResourcePool.Enqueue(temp);
            temp.transform.parent = parent.transform;
        }
    }


    public GameObject PopFromPool()
    {
        return spaceResourcePool.Dequeue();
    }

    public void PushToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.Rotate(0, 0, 0);
        spaceResourcePool.Enqueue(gameObject);
    }
}
