﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneStageBossController : MonoBehaviour {
    public GameObject NormalBullet;
    public GameObject SkillBullet;
    OneStageBoss boss;

	void Start ()
    {
        boss = new OneStageBoss(new NormalState(NormalBullet, SkillBullet),NormalBullet,SkillBullet);
        boss.Move();
        boss.Attack(gameObject);
        StartCoroutine(BossState());
	}
	
    IEnumerator BossState()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            boss.HandleState("AnnoyedState");
            boss.Move();
            boss.Attack(gameObject);
            yield return new WaitForSeconds(2);
            boss.HandleState("AngerState");
            boss.Move();
            boss.Attack(gameObject);
        }

    }
}
