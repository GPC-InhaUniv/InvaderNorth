using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IUseable
{
    ItemExplosion itemExplosion;

    private void Awake()
    {
        
    }

    private void Start()
    {
        itemExplosion = new ItemExplosion();
        StartCoroutine(ExitItemEffect());
    }

    private void FixedUpdate()
    {
        StartCoroutine(ExitItemEffect());
    }

    IEnumerator ExitItemEffect()
    {
        itemExplosion.Explode();

        yield return new WaitForSeconds(2);

        //itemExplosion.explosionRange.SetActive(false);
        //itemExplosion.bombExplosionFX.SetActive(false);

    }
    public void ApplyTheEffect()
    {
    }
}
