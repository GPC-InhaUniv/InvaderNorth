using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    private void Awake()
    {
        gameObject.AddComponent<ItemExplosion>();
        gameObject.AddComponent<ItemInvincibility>();
    }

    public override void ApplyTheEffect() { }

    public void BeUsed()
    {
        
    }

    public void BeProducedIn()
    {
        
    }
}
