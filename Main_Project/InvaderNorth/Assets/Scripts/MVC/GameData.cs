using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {
    public const int maxHpLevel = 10;
    public const int maxBulletLevel = 20;
    public const int maxCritLevel = 20;
    public const int maxTotalLevel = 50;

    [SerializeField]
    [Header("UserData")]
    public string id;
    public string password;
    public int credit;
    public int hpLevel;
    public int bulletLevel;
    public int critLevel;
    public int highestScore;
    public int totalScore;

    [Header("InGameData")]
    public int creditInGame;
    public int hpInGame;

}
