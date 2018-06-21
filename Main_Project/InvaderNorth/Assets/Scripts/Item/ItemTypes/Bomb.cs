using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    [SerializeField]
    private GameObject ExplosionRange;
    
    private void Awake()
    {
        ExplosionRange.GetComponent<GameObject>();
        gameObject.AddComponent<ItemExplosion>();
        gameObject.AddComponent<ItemInvincibility>();
    }
    
    public override void ApplyTheEffect()
    {
        
    }

    public void BeUsed()
    {
        
    }

    public void BeProducedIn()
    {
        
    }
}
