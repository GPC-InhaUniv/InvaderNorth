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
        DontDestroyOnLoad(gameObject);
        if(ItemPoolInstance == null)
        {
            ItemPoolInstance = this;
        }

        if (bombPool == null)
        {
            bombPool = GetComponent<BombPool>();
        }

        if (shieldPool == null)
        {
            shieldPool = GetComponent<ShieldPool>();
        }

        if (darkResourcePool == null)
        {
            darkResourcePool = GetComponent<DarkResourcePool>();
        }

        else
            return;
    }

}
