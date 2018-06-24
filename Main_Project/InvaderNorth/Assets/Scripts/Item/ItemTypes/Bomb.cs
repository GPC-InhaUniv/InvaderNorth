using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    public ItemExplosion itemExplosion;
    public GameObject Player;
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //gameObject.transform.parent = Player.transform;
        itemExplosion = GetComponent<ItemExplosion>();
    }

    public void LeaveBombFromPlayer()
    {
        itemExplosion.LeaveBombFromPlayer(Player);
    }

    public void StartTheEffect()
    {
        itemExplosion.StartTheEffect(gameObject);
    }

    public void StopTheEffect()
    {
        itemExplosion.StopTheEffect();
    }
}
