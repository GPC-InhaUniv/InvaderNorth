using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public enum ItemType
    {
        Bomb,
        Shield,
        Magnetic,
        DarkResource,
    }

    protected string itemName;
    protected int resourceCount;
    protected float itemDamage;
    protected float effectCountiuanceTime;
    protected bool receiveDamage;

    public abstract void ApplyTheEffect();
    
    public abstract void BeUsed();

    public abstract void BeProducedIn();
}
