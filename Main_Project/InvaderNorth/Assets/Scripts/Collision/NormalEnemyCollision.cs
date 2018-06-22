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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" )
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
        else if (other.name == "PlayerBullet")
            ObjectPoolManager.ObjectPools.PlayerBulletPool.PushToPool(other.gameObject);

        StageController.SendScoreDelegate(scoreValue, false);
        ObjectPoolManager.ObjectPools.EnemyPool.PushToPool(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}

