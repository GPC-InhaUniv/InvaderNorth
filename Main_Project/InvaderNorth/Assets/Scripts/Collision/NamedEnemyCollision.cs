using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NamedEnemyCollision : MonoBehaviour
{
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
    [SerializeField]
    private bool isBoss;
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
        }
        else if(other.name == "PlayerBullet")
        {
            ObjectPoolManager.ObjectPools.PlayerBulletPool.PushToPool(other.gameObject);
            healthPoint--;
        }

        if (healthPoint <= 0)
        {
            if(isBoss)
                GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>().enabled = false;
            GameObject temp;
            for (int i = 0; i < creditAmount; i++)
            {
                temp = ObjectPoolManager.ObjectPools.CreditPool.PopFromPool();
                temp.transform.position = transform.position;
                temp.SetActive(true);
            }
            StageController.SendScoreDelegate(scoreValue, isBoss);
            gameObject.SetActive(false);
            Instantiate(explosion, transform.position, transform.rotation);

            GameObject Item;
            Item = ObjectPoolManager.ObjectPools.bombPool.PopFromPool();
            Item.SetActive(true);
        }
    }

    public int getHealthPoint()
    {
        return healthPoint;
    }
}

