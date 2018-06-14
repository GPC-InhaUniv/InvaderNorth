using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    new Rigidbody rigidbody;
    public float speed;

    private void Start()
    {
        if(rigidbody == null)
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = transform.forward * speed;
    }
}
