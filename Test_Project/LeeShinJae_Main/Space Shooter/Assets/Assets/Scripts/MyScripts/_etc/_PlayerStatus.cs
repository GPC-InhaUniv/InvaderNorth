using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerStatus : MonoBehaviour
{
    public static _PlayerStatus instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public int playerHP=10;
    public int enemyHP=10;
    public float speed=10;

}
