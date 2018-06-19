using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItemPool : MonoBehaviour
{
    [Header("ItemPrefabs")]
    public GameObject Bomb;
    public GameObject Shield;
    public GameObject Magnetic;
    public GameObject DarkResource;

    [Header("ItemMaxNumber")]
    public int NumberOfBombs;
    public int NumberOfShields;
    public int NumberOfMagnetics;
    public int NumberOfDarkResource;
   
    Dictionary<string, GameObject> itemPool;
    private int MaxIndexItem;
    private GameObject tempItem;

    private void Start()
    {
        MaxIndexItem 
            = NumberOfBombs + NumberOfDarkResource + NumberOfMagnetics + NumberOfShields;
        itemPool = new Dictionary<string, GameObject>();

        CreatItemPool(Bomb, "Bomb", NumberOfBombs);
        CreatItemPool(Shield, "Shield", NumberOfShields);
        CreatItemPool(Magnetic, "Magnetic", NumberOfMagnetics);
        CreatItemPool(DarkResource, "DarkResource", NumberOfDarkResource);
    }
    

    private void CreatItemPool(GameObject itemObject, string itemName, int NumberOfItems)
    {
        for (int i = 1; i <= NumberOfItems; i++) 
        {
            itemPool.Add(itemName + i, Instantiate(itemObject));
            tempItem = itemPool[itemName + i];
            tempItem.name = itemName + i;
            DontDestroyOnLoad(tempItem);
        }
    }

    public GameObject PopFormItemPool(string itemName)
    {
        for (int i = 1; i <= MaxIndexItem; i++) 
        {
            if (itemPool.ContainsKey(itemName + i) == true) 
            {
                tempItem = itemPool[itemName + i];
                tempItem.SetActive(true);
                itemPool.Remove(itemName + i);
                return tempItem;
            }
        }
        return null;
    }

    public void PushToItemPool(GameObject item)
    {
        item.SetActive(false);
        itemPool.Add(item.name, item);
    }
}
