using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ItemManager : MonoBehaviour {

    public static _ItemManager instance;

    private void Awake()
    {
        countDarkResource = 10;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public int totalDarkResource;
    public int countDarkResource;
    public int acquiredDarkResource;
}
