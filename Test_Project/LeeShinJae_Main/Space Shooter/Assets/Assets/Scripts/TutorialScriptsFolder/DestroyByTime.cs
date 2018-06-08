using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    //이펙트 객체가 남아있을 수 있는 시간.
    public float lifeTime; 
    private void Start()
    {
        //파괴한다(gameObject를 lifeTime후에)
        Destroy(gameObject, lifeTime);
    }
}
