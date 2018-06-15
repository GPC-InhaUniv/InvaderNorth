using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float speed;

    void OnEnable()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
