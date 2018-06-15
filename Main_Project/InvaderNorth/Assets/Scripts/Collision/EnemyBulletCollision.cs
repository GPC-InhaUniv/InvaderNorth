using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour {

    public GameObject PlayerExplosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" || other.name == "PlayerBullet")
        {
            return;
        }

        if (other.tag == "Player")
        {
            ObjectPoolManager.PoolManager.EnemyBulletPool.PushToPool(gameObject);
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            GameObject player = other.gameObject;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.transform.rotation = Quaternion.Euler(Vector3.zero);
            other.gameObject.SetActive(false);
            TutorialController.DecreaseDelegate(player);
            //gameController.GameOver();
        }

        

    }
}
