using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NamedEnemyCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject Explosion;
    [SerializeField]
    private GameObject PlayerExplosion;
    [SerializeField]
    private int ScoreValue;
    [SerializeField]
    private int Hp;
    [SerializeField]
    private bool IsBoss;
    private int maxHp;

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
            StageController.DecreaseDelegate(player);
        }
        else if(other.name == "PlayerBullet")
        {
            ObjectPool.ObjectPools.PlayerBulletPool.PushToPool(other.gameObject);
            Hp--;
        }

        if (Hp <= 0)
        {
        StageController.SendScoreDelegate(ScoreValue, IsBoss);
        gameObject.SetActive(false);
        Instantiate(Explosion, transform.position, transform.rotation);
        }
    }
}

