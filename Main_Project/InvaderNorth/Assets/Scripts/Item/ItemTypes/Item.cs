using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    protected ItemEffect itemType;
    protected GameObject Player;
    protected GameObject BombObject;
    protected GameObject BombExplosionRange;

    
    public void LeaveItemFromPlayer()
    {
        itemType.LeaveItemFromPlayer(Player, BombObject, BombExplosionRange);
    }

    public void StartTheEffect()
    {
        itemType.StartTheEffect(BombObject, BombExplosionRange);
    }

    public void StopTheEffect()
    {
        itemType.StopTheEffect(BombExplosionRange);
    }
}
