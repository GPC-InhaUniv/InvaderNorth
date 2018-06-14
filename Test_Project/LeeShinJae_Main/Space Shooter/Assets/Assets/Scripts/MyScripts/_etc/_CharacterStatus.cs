using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterStatus : MonoBehaviour
{
    public static _CharacterStatus instance; // 임시 매니저

    private int playerHP;
    private int enemyHP;
    private float speed;
    
    public int PlayerHP { get; set;}
    public int EnemyHP { get; set; }
    public float Speed { get;set; }

    private void Awake()
    {
        playerHP = 4;
        enemyHP = 2;
        speed = 10;
    }
}
