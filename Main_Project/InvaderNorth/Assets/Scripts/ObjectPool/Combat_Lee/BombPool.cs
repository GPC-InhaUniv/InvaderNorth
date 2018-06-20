using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPool : MonoBehaviour
{
    public GameObject itemObject;
    public GameObject Parent;

    Queue<GameObject> itemPool;
    [SerializeField]
    private int MaxNumberOfBomb;
    
    private void Start()
    {
        MaxNumberOfBomb = 3;
        itemPool = new Queue<GameObject>();
        CreatBombPool();
    }

    private void CreatBombPool()
    {
        for (int i = 1; i <= MaxNumberOfBomb; i++ )
        {
            itemObject = Instantiate(itemObject);
            itemObject.name = "Bomb";
            itemPool.Enqueue(itemObject);
            itemObject.transform.parent = Parent.transform;
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
   