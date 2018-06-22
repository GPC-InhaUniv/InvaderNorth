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
    private int hp;
    [SerializeField]
    private bool isBoss;
    private int maxHp;

    void Awake()
    {
        maxHp = hp;
    }

    void OnEnable()
    {
        hp = maxHp;
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
            hp--;
        }

        if (hp <= 0)
        {
        StageController.SendScoreDelegate(scoreValue, isBoss);
        gameObject.SetActive(false);
        Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}

