using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Collider들의 충돌처리 부모클래스
public abstract class CollisionForm : MonoBehaviour {

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boundary"))
            Destroy(gameObject);
    }
    
    protected abstract void OnTriggerEnter(Collider other);
}
