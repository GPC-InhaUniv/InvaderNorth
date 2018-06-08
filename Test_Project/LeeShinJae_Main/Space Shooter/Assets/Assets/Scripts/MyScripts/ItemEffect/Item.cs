using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected string itemName;
    protected float itemDamage;
    protected int resourceCount;
    protected float effectCountiuanceTime;

    protected abstract void GetItemDescription();
    
    protected abstract void BeUsed();

    protected abstract void BeProducedIn();
}
