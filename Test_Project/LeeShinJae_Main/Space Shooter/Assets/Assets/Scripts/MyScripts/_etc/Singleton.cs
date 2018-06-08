using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;

                if(instance == null)
                {
                    Debug.LogError("그곳에는" + typeof(PooledObject) + " 가 활성화되지 않았습니다.");
                }
            }
            return instance;
        }
    }
	
}
