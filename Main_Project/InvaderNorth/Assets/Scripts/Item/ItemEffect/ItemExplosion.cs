using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion : ItemEffectType
{
    private GameObject ExplosionRange;
    private GameObject FXBombExplosion;
    private int BombEffectLimitTime;
    
    private ItemExplosion()
    {
        BombEffectLimitTime = 20;
        ExplosionRange = Resources.Load("Prefabs/BombExplosion") as GameObject;
        FXBombExplosion = Resources.Load("Prefabs/FXBombExplosion") as GameObject;

        ExplosionRange.SetActive(false);
        FXBombExplosion.SetActive(false);
    }

    public override void ApplyTheEffect()
    {
        base.ApplyTheEffect();
        Explode();
    }
    
    //여기에 폭발범위, 폭발이펙트 활성화 / 이후 비활성화
    IEnumerator Explode()
    {
        for (int i = 0; i <= BombEffectLimitTime; i++)
        {
            ExplosionRange.SetActive(true);
            FXBombExplosion.SetActive(true);

            yield return new WaitForSeconds(0.1f);
        }

        ExplosionRange.SetActive(false);
        FXBombExplosion.SetActive(false);
        
    }
}
