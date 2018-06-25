using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion :ItemEffect
{
    public ItemExplosion(Transform Player, GameObject BombObject, GameObject BombExplosionRange)
    {
        this.bombObject = BombObject;
        this.player = Player;
        this.bombExplosionRange = BombExplosionRange;
        this.bombExplosionRange.SetActive(false);
    }
    
    public override void LeaveItemFromPlayer()
    {
        
        bombObject = ObjectPoolManager.ObjectPools.bombObjects.PopFromPool();
        
        Vector3 position = this.player.transform.position;
        
        bombObject.transform.parent = player.transform;
        bombObject.SetActive(true);
        Debug.Log("폭탄 발사");
    }

    public override void StartTheEffect()
    {
        bombObject.SetActive(false);
        ObjectPoolManager.ObjectPools.bombObjects.PushToPool(bombObject);
        
        bombExplosionRange.transform.parent = bombObject.transform;

        bombObject.SetActive(false);
        bombExplosionRange.SetActive(true);
        Debug.Log("폭발 실행");
        
    }

    public override void StopTheEffect()
    {
        bombExplosionRange.SetActive(false);
        Debug.Log("폭발 종료");
    }
}
