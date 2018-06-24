using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    
    public Bomb(GameObject Player, GameObject BombObject, GameObject BombExplosionRange)
    {
        itemType = new ItemExplosion(BombObject, BombExplosionRange);
        
    }
}
