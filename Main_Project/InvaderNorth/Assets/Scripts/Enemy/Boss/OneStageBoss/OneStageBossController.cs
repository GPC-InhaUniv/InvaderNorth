﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneStageBossController : MonoBehaviour {
    [SerializeField]
    private GameObject normalBullet;
    [SerializeField]
    private GameObject skillBullet;
    private OneStageBoss boss;

	void Start ()
    {
        boss = new OneStageBoss(new NormalState(normalBullet, skillBullet), normalBullet, skillBullet);
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
