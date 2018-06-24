using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion : ItemType
{
    public GameObject BombObject;
    public GameObject BombExplosionRange;

    //public delegate void SendStartEffectPosition(GameObject ParentObject);
    //public static SendStartEffectPosition StartEffectPosition;
    
    public ItemExplosion()
    {
        BombObject = Resources.Load("Prefabs/BombObject") as GameObject;
        BombObject.SetActive(true);

        BombExplosionRange = Resources.Load("Prefabs/VFX/Explosions/BombExplosionFX") as GameObject;
        BombExplosionRange.SetActive(true);

       //StartEffectPosition += StartTheEffect;
    }
    
    public void LeaveBombFromPlayer(GameObject player)
    {
        Vector3 position = player.transform.position;
        BombObject.transform.position = player.transform.position;
        BombExplosionRange.transform.position = player.transform.position;

        BombObject.SetActive(true);
    }

    public void StartTheEffect(GameObject BombObject)
    {
        BombExplosionRange.transform.parent = BombObject.transform;

        BombObject.SetActive(false);
        BombExplosionRange.SetActive(true);
    }

    public void StopTheEffect()
    {
        BombExplosionRange.SetActive(false);
    }
}
