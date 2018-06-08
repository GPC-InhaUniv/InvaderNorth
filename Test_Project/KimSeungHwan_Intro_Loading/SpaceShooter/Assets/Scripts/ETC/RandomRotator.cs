using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    public Rigidbody rigidbody;

    void Start()
    {
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
