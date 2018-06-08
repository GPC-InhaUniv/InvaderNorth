using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;
    public Rigidbody rigidbody;

    void Start()
    {
        rigidbody.velocity = transform.forward * speed;
    }
}