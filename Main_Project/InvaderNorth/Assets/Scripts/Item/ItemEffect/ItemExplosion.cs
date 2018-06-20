using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion : ItemEffectType
{
    public Collider ExplosionRange;
    public GameObject NormalEnemy;
    public GameObject NamedEnemy;
    
    public bool isUsedItem;

    
    private float itemDamage;


    private void Awake()
    {
        itemDamage = 10;
        ExplosionRange = GetComponent<Collider>();
        ExplosionRange.enabled = false;
    }

    protected ItemExplosion(Item item)
        : base(item)
    { }

    public override void ApplyTheEffect()
    {
        base.ApplyTheEffect();
        Explosion();
    }

    public void Explosion()
    {
        if (isUsedItem == true)
        {
            ExplosionRange.enabled = true;
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {

        }
    }


}
