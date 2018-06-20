using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjectPool : MonoBehaviour
{
    public static ItemObjectPool ItemPoolInstance;
    public BombPool bombPool;
    public ShieldPool shieldPool;
    public DarkResourcePool darkResourcePool;

    private void Start()
    {
        if (bombPool == null)
        {
            bombPool = GetComponent<BombPool>();
        }
        else if (shieldPool == null)
        {
            shieldPool = GetComponent<ShieldPool>();
        }
        else if (darkResourcePool == null)
        {
            darkResourcePool = GetComponent<DarkResourcePool>();
        }

        else
            Debug.Log("아이템 풀 값이 들어오지 않음");
    }

}
