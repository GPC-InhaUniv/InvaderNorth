using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMover : MonoBehaviour {

    private Rigidbody rigidbody;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
            StartCoroutine(FirstMove());
    }

    IEnumerator FirstMove()
    {
        float risingLimitZ = transform.position.z;
        risingLimitZ += Random.Range(1.5f, 2.5f);
        Vector3 direction = new Vector3(Random.Range(-1.5f, 1.5f), 0, 1);


        while (true)
        {
            rigidbody.velocity = direction * 2.5f;
            if (transform.position.z > risingLimitZ)
            {
                if (!StageController.IsGameOver)
                    yield return SecondMove();
                break;
            }
            yield return null;

        }
        yield return null;

    }

    IEnumerator SecondMove()
    {

        while (true)
        {
            
            Vector3 direction = (player.transform.position - transform.position).normalized;
            rigidbody.velocity = direction * 30;
   
            yield return null;
        }
            
    }

}
