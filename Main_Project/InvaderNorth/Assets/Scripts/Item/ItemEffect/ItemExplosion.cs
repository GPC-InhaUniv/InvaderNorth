using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion : ItemEffectType
{
    [Header("BombExplosionObjects")]
    [SerializeField]
    private GameObject ExplosionRange;
    [SerializeField]
    private GameObject BombExplosion;
   
  
    private void Start()
    {
        
    }
    
    public override void ApplyTheEffect()
    {
        base.ApplyTheEffect();
        
        Explode();
    }
    
    public void Explode()
    {
       
    }
}
