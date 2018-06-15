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
        //totalResourceCount는 데이터매니저에서 받아온다. 일단 임시로 100으로 해놓음
        totalResourceCount = 100;
    }

    protected ItemAccumulation(Item item)
        :base(item) 
    { }

    public override void ApplyTheEffect()
    {
        base.ApplyTheEffect();
        AddResource();
    }

    public void AddResource()
    {

    }
}
