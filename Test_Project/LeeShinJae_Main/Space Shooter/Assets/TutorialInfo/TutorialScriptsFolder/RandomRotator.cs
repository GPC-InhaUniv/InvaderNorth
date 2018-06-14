using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    new Rigidbody rigidbody;
    private void Start()
    {
        if(rigidbody == null)
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
