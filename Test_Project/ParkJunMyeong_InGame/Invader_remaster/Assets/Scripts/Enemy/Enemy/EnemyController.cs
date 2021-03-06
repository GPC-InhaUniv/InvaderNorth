﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyName     //몬스터를 구별하여 패턴을 지정하기 위해 사용.
{
    NormalEnemy, 
    MultiShotEnemy,
}

public class EnemyController : MonoBehaviour {
    public float SkillCoolTime;       //스킬 사용의 텀을 두기 위해.
    public EnemyName EnemyName ;      
    Enemy enemy;
    AudioSource ShotAudio;

    void Start ()
    {
        ShotAudio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().Play();
        switch (EnemyName)             //구별하여 패턴을 지정.
        {
            case EnemyName.NormalEnemy:
                enemy = new NormalEnemy(GetComponent<Rigidbody>());
                break;

            case EnemyName.MultiShotEnemy:
                enemy = new MultiShotEnemy(GetComponent<Rigidbody>());
                break;

        }
        StartCoroutine(Attack());
        StartCoroutine(Move());
    }

    void OnEnable()                  //활성화 시 호출되는 함수.
    {
        if(enemy != null)           //처음에는 실행 안되게
        {
            StartCoroutine(Attack());
            StartCoroutine(Move());
        }    
    }

    IEnumerator Attack()             //공격
    {
        
        while (true)
        {
            enemy.Attack(gameObject);
            ShotAudio.Play();
            yield return new WaitForSeconds(SkillCoolTime);
            if (SkillCoolTime > 0)
            {
                enemy.SkillUse(gameObject);
                ShotAudio.Play();
            }
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator Move()             //이동
    {
        while(true)
        {
            enemy.Move(gameObject);
            yield return null;
        }
        
    }







}
