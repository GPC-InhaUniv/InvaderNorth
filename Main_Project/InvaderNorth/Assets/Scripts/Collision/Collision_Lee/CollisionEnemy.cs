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
            switch(other.gameObject.name)
            {
                case "PlayerBullet":
                    Hp--;
                    break;

                case "BombObject":
                    ItemController.SendStartEffectDelegate();
                    Hp = Hp - 10;
                    break;

                case "BombExplosionFX":
                    Hp = Hp - 5;
                    break;
            }
            
        }

        if (Hp <= 0)
        {
            StageController.SendScoreDelegate(ScoreValue, IsBoss);
            ObjectPoolManager.ObjectPools.EnemyPool.PushToPool(gameObject);
            Instantiate(Explosion, transform.position, transform.rotation);

            ObjectPoolManager.ObjectPools.bombPool.PopFromPool();
           
        }

        else
            return;
    }
}
