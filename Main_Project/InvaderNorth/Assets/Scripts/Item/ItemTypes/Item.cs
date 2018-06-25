using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    protected ItemEffect upgradeType;
    protected GameObject Player;
    protected GameObject BombObject;
    protected GameObject BombExplosionRange;

    
    public void LeaveItemFromPlayer()
    {
        upgradeType.LeaveItemFromPlayer();
    }

    public void StartTheEffect()
    {
        upgradeType.StartTheEffect();
    }

    public void StopTheEffect()
    {
        upgradeType.StopTheEffect();
    }
}
