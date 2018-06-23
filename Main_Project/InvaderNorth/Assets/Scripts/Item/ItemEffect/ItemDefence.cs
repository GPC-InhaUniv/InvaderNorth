using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//쉴드오브젝트
public class ItemDefence : ItemEffectType
{
    private bool receiveDamage;
    private float effectCountiuanceTime;
    //private GameObject barrier;
    //private GameObject barrierFX;
    
    private ItemDefence()
    {
        //barrier = Resources.Load("Prefab/Barrier") as GameObject;
        //barrierFX = Resources.Load("Prefab/BarrierFX") as GameObject;

    }
    public override void ApplyTheEffect()
    {
        base.ApplyTheEffect();
        DontBeAttacked();
    }
    public void DontBeAttacked()
    {
        
    }
}
