using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyCollision : MonoBehaviour {

    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject playerExplosion;
    [SerializeField]
    private int scoreValue;
    [SerializeField]
    private int healthPoint;
    [SerializeField]
    private int creditAmount;
    private int maxhealthPoint;

    void Awake()
    {
        maxhealthPoint = healthPoint;
    }

    void OnEnable()
    {
        healthPoint = maxhealthPoint;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            GameObject player = other.gameObject;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.transform.rotation = Quaternion.Euler(Vector3.zero);
            other.gameObject.SetActive(false);
            StageController.DecreaseDelegate(player);
            healthPoint--;
        }
        else if (other.name == "PlayerBullet")
        {
            ObjectPoolManager.ObjectPools.PlayerBulletPool.PushToPool(other.gameObject);
            healthPoint--;
        }
        else if (other.name == "BombObject")
        {
            GameObject BombExplosionFX = ObjectPoolManager.ObjectPools.bombExplosionFXs.PopFromPool();
            BombExplosionFX.SetActive(true);
            ItemController.SendStartEffectDelegate(BombExplosionFX, other.gameObject);
            healthPoint = healthPoint - 10;
            //ObjectPoolManager.ObjectPools.EnemyPool.PushToPool(gameObject);
            //Instantiate(explosion, transform.position, transform.rotation);
        }

        else if (other.name == "BombExplosionFX")
        {
            ///ItemController.SendStartEffectDelegate(other.gameObject);
            ObjectPoolManager.ObjectPools.bombExplosionFXs.PushToPool(other.gameObject);
            other.transform.position = gameObject.transform.position;
            //   ObjectPoolManager.ObjectPools.EnemyPool.PushToPool(gameObject);
            //    Instantiate(explosion, transform.position, transform.rotation);
            healthPoint = healthPoint - 5;
        }

        if (healthPoint <= 0)
        {
            GameObject temp;
            for (int i = 0; i < creditAmount; i++)
            {
                temp = ObjectPoolManager.ObjectPools.CreditPool.PopFromPool();
                temp.transform.position = transform.position;
                temp.SetActive(true);
            }
            StageController.SendScoreDelegate(scoreValue, false);
            ObjectPoolManager.ObjectPools.EnemyPool.PushToPool(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            
            GameObject Item;    // PlayerBullet 충돌 조건에 있던걸 체력이 생겨서 위에꺼는 지웠습니다.
            Item = ObjectPoolManager.ObjectPools.bombPool.PopFromPool();
            Item.transform.position = gameObject.transform.position;
            Item.SetActive(true);
        }

        


    }
}

