using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion : ItemEffect
{

    public ItemExplosion(Transform Player, GameObject ItemObject, GameObject BombExplosionRange)
    {
        this.bombObject = ItemObject;
        this.player = Player;
        this.bombExplosionRange = BombExplosionRange;
        this.bombExplosionRange.SetActive(false);

    }

    public override void LeaveItemFromPlayer()
    {
        bombObject.SetActive(true);
        Debug.Log("폭탄 발사");
    }

    public override GameObject StartTheEffect(GameObject bombExplosionRange, GameObject ItemPosition)
    {
        bombExplosionRange.transform.position = ItemPosition.transform.position;
        ItemPosition.transform.position = Vector3.zero;
        ObjectPoolManager.ObjectPools.bombObjects.PushToPool(ItemPosition);
        bombObject.SetActive(false);
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
