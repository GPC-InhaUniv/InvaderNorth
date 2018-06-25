using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemEffect
{
    protected Transform player;
    protected GameObject bombObject;
    protected GameObject bombExplosionRange;

    public abstract void LeaveItemFromPlayer(GameObject ItemObject);

    public abstract GameObject StartTheEffect(GameObject EffectRange, GameObject ItemPosition);

    public abstract void StopTheEffect();
}
