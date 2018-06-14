using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ResourceManager : MonoBehaviour {

    public static _ResourceManager instance;

    public int totalDarkResource; // 암흑물질 총 개수
    public int countDarkResourceUnit; // 개당 올라가는 함흑물질 개수
    public int acquiredDarkResource; // 암흑물질 축적 수 

    private void Awake()
    {
        totalDarkResource = 0;
        countDarkResourceUnit = 10;
        acquiredDarkResource = 0;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }

    
}
