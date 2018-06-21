using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//재화누적효과
public class ItemAccumulation : ItemEffectType {
    //자원 축적
    private int resourceCount;
    private int totalResourceCount;

    private void Awake()
    {
        resourceCount = 10;
        totalResourceCount = 0;
        item = GetComponent<Item>();
        
    }
    
    public override void ApplyTheEffect()
    {
        base.ApplyTheEffect();
        AddResource();
    }

    public void AddResource()
    {
        totalResourceCount = resourceCount + totalResourceCount;
    }
}
