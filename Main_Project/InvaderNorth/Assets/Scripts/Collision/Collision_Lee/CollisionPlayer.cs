using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : CollisionForm
{
    public GameObject Explosion;
    public GameObject PlayerExplosion;
    public int ScoreValue;
    public int Hp;
    public bool IsBoss;
  

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
            gameObject.SetActive(false);
            StageController.DecreaseDelegate(gameObject);
        }
        
        if (other.CompareTag("Item"))
        {
            return;
        }

        else
            return;
    }
}
