using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    [SerializeField]
    private float speed;

    void OnEnable()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
