using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion : ItemEffectType
{
    [Header("BombExplosionObjects")]
    [SerializeField]
    private GameObject ExplosionRange;
    private GameObject BombExplosion;
    private GameObject Parent;

    [Header("EnemyExplosionObjects")]
    public GameObject NormalEnemy;
    public GameObject NamedEnemy;
    public GameObject EnemyExplosion;
    
    public bool isUsedItem;
    //인벤토리(1칸) 구축 후 그곳에 InputManager이용

    
    private float itemDamage;


    private void Awake()
    {
        itemDamage = 10;
        ExplosionRange = GetComponent<GameObject>();
        ExplosionRange.SetActive(false);
  
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
            ExplosionRange.SetActive(true);
            Instantiate(BombExplosion, Parent.transform.position, Parent.transform.rotation);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ObjectPool.ObjectPools.EnemyPool.PushToPool(other.gameObject);
            ObjectPool.ObjectPools.EnemyBulletPool.PushToPool(other.gameObject);
            Instantiate(EnemyExplosion,other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
        }
        else
            return;
    }


}
