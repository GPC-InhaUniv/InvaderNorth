using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkResource : MonoBehaviour
{
    //DarkResource 아이템은 소모아이템이 아니므로 소모아이템과는 따로 둠
    private CollisionItem collisionItem;
    private int DarkResourceCount;
    private int DarkResourceAmount;
    
    private void Awake()
    {
        DarkResourceCount = 10;
        DarkResourceAmount = 0;
    }

    private void Update()
    {
        if (collisionItem.DarkResourceAcquisition == true)
        {
            DarkResourceAmount = AddResource(DarkResourceCount, DarkResourceAmount);
            collisionItem.DarkResourceAcquisition = false;
        }
    }

    public int AddResource(int DarkResourceCount, int DarkResourceAmount)
    {
        int Result;
        Result = DarkResourceCount + DarkResourceAmount;

        return Result;
    }
}
