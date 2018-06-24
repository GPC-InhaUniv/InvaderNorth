using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion : ItemType
{
    public GameObject explosionRange;
    public GameObject bombExplosionFX;

    //public delegate void SendPlayerPosition(GameObject player);
    //public static SendPlayerPosition sendPosition;
    //public delegate void SendStopEffect();
    //public static SendStopEffect sendStopEffect;

    
    public ItemExplosion()
    {
        explosionRange = Resources.Load("Prefabs/BombExplosion") as GameObject;
        explosionRange.SetActive(true);

        bombExplosionFX = Resources.Load("Prefabs/VFX/Explosions/BombExplosionFX") as GameObject;
        bombExplosionFX.SetActive(true);
        //sendPosition += ExertAnEffect;
        //sendStopEffect += StopTheEffect;
    }
    
    
    public void ExertAnEffect(GameObject player)
    {
        Vector3 position = player.transform.position;
        explosionRange.transform.position = player.transform.position;
        bombExplosionFX.transform.position = player.transform.position;

        explosionRange.SetActive(true);
        bombExplosionFX.SetActive(true);
        
    }

    public void StopTheEffect()
    {
        explosionRange.SetActive(false);
        bombExplosionFX.SetActive(false);
    }

    

    


}
