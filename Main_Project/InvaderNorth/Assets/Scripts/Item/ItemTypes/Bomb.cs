using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    
    public Bomb(Transform Player,GameObject BombExplosionRange)
    {
        itemType = new ItemExplosion(Player, BombExplosionRange);
    }
}
