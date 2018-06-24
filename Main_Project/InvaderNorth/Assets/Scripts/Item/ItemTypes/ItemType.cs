using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemEffect
{
    protected GameObject Player;
    protected GameObject BombObject;
    protected GameObject BombExplosionRange;

    public abstract void LeaveItemFromPlayer(GameObject player, GameObject bombObject, GameObject bombExplosion);

    public abstract void StartTheEffect(GameObject BombObject, GameObject bombExplosionRange);

    public abstract void StopTheEffect(GameObject bombExplosionRange);
}
