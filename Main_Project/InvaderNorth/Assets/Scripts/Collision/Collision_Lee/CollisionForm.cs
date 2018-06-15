using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Collider들의 충돌처리 부모클래스
public abstract class CollisionForm : MonoBehaviour {

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boundary"))
            //파괴는 테스트용 본래는 오브젝트풀로 반환
            Destroy(gameObject);
    }
    
    protected abstract void OnTriggerEnter(Collider other);
}
