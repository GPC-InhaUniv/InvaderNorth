using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    public ItemExplosion itemExplosion;
    public GameObject Player;

    private void OnEnable()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Start()
    {
        
    }
    
    

    public void ExertAnEffect()
    {
        itemExplosion.ExertAnEffect(Player);
    }

    public void StopTheEffect()
    {
        itemExplosion.StopTheEffect();
    }
}
