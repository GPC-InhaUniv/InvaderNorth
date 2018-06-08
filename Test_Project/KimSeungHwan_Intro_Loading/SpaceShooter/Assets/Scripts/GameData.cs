using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {
    private const int maxHpLevel = 10;
    private const int maxBulletLevel = 20;
    private const int maxCritLevel = 20;
    private const int maxTotalLevel = 50;

    [SerializeField]
    [Header("UserData")]
    public string id;
    public string password;
    public int totalLevel;
    public int credit;
    public int hpLevel;
    public int bulletLevel;
    public int critLevel;

    [Header("InGameData")]
    public int creditInGame;
    public int hpInGame;

}
