using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemy : CollisionForm
{

    public GameObject Explosion;
    public GameObject PlayerExplosion;
    public int ScoreValue;
    public int Hp;
    public bool IsBoss;
    int maxHp;

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            gameObject.SetActive(false);
            Hp--;
        }

        else if (other.CompareTag("PlayerBullet"))
        {
            Hp--;
        }

        if (Hp <= 0)
        {
            StageController.SendScoreDelegate(ScoreValue, IsBoss);
            ObjectPoolManager.ObjectPools.EnemyPool.PushToPool(gameObject);
            Instantiate(Explosion, transform.position, transform.rotation);
        }

        else
            return;
    }
}
