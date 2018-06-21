using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//폭발효과
public class ItemExplosion : ItemEffectType
{

    [Header("BombExplosionObjects")]
    [SerializeField]
    private GameObject ExplosionRange;
    [SerializeField]
    private GameObject BombExplosion;
   
    [Header("사용여부")]
    public bool isUsedItem;
    public bool HaveItem;
    //인벤토리(1칸) 구축 후 그곳에 InputManager이용

    public float itemDamage;
    
    private void Awake()
    {
        isUsedItem = false;
        itemDamage = 10;
        item = GetComponent<Item>();
        ExplosionRange = GetComponent<GameObject>();
        ExplosionRange.SetActive(false);
    }
    
    public override void ApplyTheEffect()
    {
        base.ApplyTheEffect();
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (HaveItem == true)
            {
                isUsedItem = true;
                Explode(isUsedItem);
            }
        }
    }
    
    public void Explode(bool isUsedItem)
    {
        if (isUsedItem == true)
        {
            Instantiate(BombExplosion, Parent.transform.position, Parent.transform.rotation);
            ExplosionRange.SetActive(true);
        }

        else
            return;
    }
}
