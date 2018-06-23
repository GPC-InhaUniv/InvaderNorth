using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion : ItemEffectType
{
    //public GameObject explosionRange;
    //public GameObject bombExplosionFX;

    public ItemExplosion()
    {
        //explosionRange = Resources.Load("Prefab/BombExplosion") as GameObject;
        //explosionRange.SetActive(false);

        //bombExplosionFX = Resources.Load("Prefab/BombExplosionFX") as GameObject;
        //bombExplosionFX.SetActive(false);
    }
    
    public override void ApplyTheEffect()
    {
        base.ApplyTheEffect();
        
        Explode();
    }
    
    public void Explode()
    {
        //explosionRange.SetActive(true);
        //bombExplosionFX.SetActive(true);
        
    }
}
