using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    protected ItemEffect itemType;
    protected GameObject Player;
    protected GameObject BombObject;
    protected GameObject BombExplosionRange;

    
    public void LeaveItemFromPlayer(GameObject itemObject)
    {
        itemType.LeaveItemFromPlayer(itemObject);
    }

    public void StartTheEffect(GameObject ExplsionRange, GameObject ItemPosition)
    {
        itemType.StartTheEffect(ExplsionRange, ItemPosition);
    }

    public void StopTheEffect()
    {
        itemType.StopTheEffect();
    }
}
