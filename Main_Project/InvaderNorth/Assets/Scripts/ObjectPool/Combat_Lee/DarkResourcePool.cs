using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkResourcePool : MonoBehaviour
{
    [SerializeField]
    private GameObject itemObject;
    [SerializeField]
    private GameObject Parent;

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
            GameObject item = Instantiate(itemObject);
            item.name = "DarkResource";
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