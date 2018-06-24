using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemEffect
{
    protected Transform player;
    protected GameObject bombObject;
    protected GameObject bombExplosionRange;

    public abstract void LeaveItemFromPlayer();

    public abstract void StartTheEffect();

    public abstract void StopTheEffect();
}
