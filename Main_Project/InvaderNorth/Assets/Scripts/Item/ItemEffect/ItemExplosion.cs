using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion :ItemEffect
{
    
    public ItemExplosion(GameObject BombObject, GameObject BombExplosionRange)
    {
        this.BombObject = BombObject;
        this.BombObject.SetActive(false);

        this.BombExplosionRange = BombExplosionRange;
        this.BombExplosionRange.SetActive(false);
        Debug.Log(BombObject.name);
    }
    
    public override void LeaveItemFromPlayer(GameObject player, GameObject bombObject, GameObject bombExplosionRange)
    {
        //Vector3 position = player.transform.position;
        bombObject.transform.position = player.transform.position;
        bombExplosionRange.transform.position = player.transform.position;

        bombObject.SetActive(true);
    }

    public override void StartTheEffect(GameObject BombObject, GameObject bombExplosionRange)
    {
        bombExplosionRange.transform.parent = BombObject.transform;

        BombObject.SetActive(false);
        bombExplosionRange.SetActive(true);
    }

    public override void StopTheEffect(GameObject bombExplosionRange)
    {
        bombExplosionRange.SetActive(false);
    }
}
