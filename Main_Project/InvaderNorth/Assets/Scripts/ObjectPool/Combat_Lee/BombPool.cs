using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPool : MonoBehaviour
{
    [SerializeField]
    private GameObject itemObject;
    [SerializeField]
    private GameObject Parent;

    Queue<GameObject> itemPool;
    public int MaxNumberOfBomb;
    
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
   