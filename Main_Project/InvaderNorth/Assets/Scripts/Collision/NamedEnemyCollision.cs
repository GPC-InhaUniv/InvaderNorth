﻿using System.Collections;
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
            healthPoint--;
        }

        else if (other.name == "PlayerBullet")
        {
            ObjectPoolManager.ObjectPools.PlayerBulletPool.PushToPool(other.gameObject);
            healthPoint--;
        }

        else if (other.name == "BombObject")
        {
            SoundManager.instance.PlaySoundType(SoundType.PlayerItemBomb);
            other.gameObject.SetActive(false);
            ObjectPoolManager.ObjectPools.bombObjects.PushToPool(other.gameObject);

            GameObject BombExplosionFX = ObjectPoolManager.ObjectPools.bombExplosionFXs.PopFromPool();
            ItemController.SendStartEffectDelegate(BombExplosionFX, other.gameObject);

            healthPoint = healthPoint - 10;
        }

        else if (other.name == "BombExplosion")
        {
            SoundManager.instance.PlaySoundType(SoundType.PlayerItemBomb);
            ObjectPoolManager.ObjectPools.bombExplosionFXs.PushToPool(other.gameObject);
            other.transform.position = gameObject.transform.position;
            healthPoint = healthPoint - 5;

        }

        if (healthPoint <= 0)
        {
            if (isBoss)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>().enabled = false;
                SoundManager.instance.PlaySoundType(SoundType.BossDie);
            }
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
            if (!isBoss)
            {
                SoundManager.instance.PlaySoundType(SoundType.EnemyDie);
                GameObject Item;
                Item = ObjectPoolManager.ObjectPools.bombPool.PopFromPool();
                Item.transform.position = gameObject.transform.position;
                Item.SetActive(true);
            }
        }
    }

    public int getHealthPoint()
    {
        return healthPoint;
    }
}

