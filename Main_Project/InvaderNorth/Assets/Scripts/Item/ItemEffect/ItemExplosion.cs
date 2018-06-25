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
    
    public override void LeaveItemFromPlayer(GameObject bombObject, Transform PlayerPosition)
    {
        Vector3 position = player.transform.position;
        position = PlayerPosition.transform.position;
        bombObject.transform.position = position;
        
        bombObject.SetActive(true);
        Debug.Log("폭탄 발사");
    }

    public override GameObject StartTheEffect(GameObject bombExplosionRange, GameObject ItemPosition)
    {
        bombExplosionRange.transform.position = ItemPosition.transform.position;
        //bombObject.SetActive(false);
        //ObjectPoolManager.ObjectPools.bombObjects.PushToPool(ItemPosition);
        
        bombExplosionRange.SetActive(true);
        Debug.Log("폭발 실행");

        return ItemPosition;
    }

    public override void StopTheEffect()
    {
        bombExplosionRange.SetActive(false);
        Debug.Log("폭발 종료");
    }
}
