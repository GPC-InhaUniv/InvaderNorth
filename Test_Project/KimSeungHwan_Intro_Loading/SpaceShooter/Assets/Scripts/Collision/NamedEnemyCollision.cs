using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamedEnemyCollision : MonoBehaviour {

    public GameObject Explosion;
    public GameObject PlayerExplosion;
    public int ScoreValue;
    public int Hp;
    public bool isBoss;
    int maxHp;

    void Awake()
    {
        maxHp = Hp;
    }

    void OnEnable()
    {
        Hp = maxHp;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            GameObject player = other.gameObject;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.transform.rotation = Quaternion.Euler(Vector3.zero);
            other.gameObject.SetActive(false);
            TutorialController.DecreaseDelegate(player);
        }
        if (other.name == "PlayerBullet")
        {
            ObjectPoolManager.PoolManager.PlayerBulletPool.PushToPool(other.gameObject);
            Hp--;
        }       
        if (Hp <= 0)
        {
            TutorialController.SendScoreDelegate(ScoreValue, isBoss);
            ObjectPoolManager.PoolManager.EnemyPool.PushToPool(gameObject);
            Instantiate(Explosion, transform.position, transform.rotation);
        }
    }
}

