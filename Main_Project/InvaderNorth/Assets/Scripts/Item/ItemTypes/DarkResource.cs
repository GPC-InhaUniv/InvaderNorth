using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkResource : MonoBehaviour
{
    private CollisionItem collisionItem;
    private int DarkResourceCount;
    private int DarkResourceAmount;

    private void Awake()
    {
        DarkResourceCount = 10;
        DarkResourceAmount = 0;
        collisionItem = GetComponent<CollisionItem>();
    }

    private void Update()
    {
        if(collisionItem.HaveDarkResource == true)
        {
            DarkResourceAmount = AddAmount(DarkResourceCount, DarkResourceAmount);
            collisionItem.HaveDarkResource = false;
        }
    }

    private int AddAmount(int Count, int Amount)
    {
        int result = Amount + Count;
        return result;
    }
}
