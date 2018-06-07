﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    //private Done_GameController gameController;
    /*
        void Start()
        {
            GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
            if (gameControllerObject != null)
            {
                gameController = gameControllerObject.GetComponent<Done_GameController>();
            }
            if (gameController == null)
            {
                Debug.Log("Cannot find 'GameController' script");
            }
          
        }
  */
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            //gameController.GameOver();
        }

        // gameController.AddScore(scoreValue);
        if (gameObject.name == "EnemyBolt")
        {
            ObjectPoolManager.PoolManager.EnemyBullets.PushToPool(gameObject);
        }
        else
        {
            ObjectPoolManager.PoolManager.EnemyPool.PushToPool(gameObject,gameObject.name);
        }
    }
}