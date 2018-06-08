using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//재화누적효과
public class ItemAccumulation : ItemEffectType {

    private readonly ItemCollision itemCollision;

    protected ItemAccumulation(Item item)
        :base(item) 
    { }
    
    protected override void GetItemDescription()
    {
        //임시 카운트(수정요망)
        if (itemCollision == true)
        {
            _ItemManager.instance.acquiredDarkResource
                += _ItemManager.instance.countDarkResource;
        }
    }

    protected override void BeUsed()
    {
        if (itemCollision)
        {
            GetItemDescription();
        }
    }
}
