using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneStageBoss 
{
    OneStageBossState bossState;
    GameObject normalBullet;
    GameObject skillBullet;


    public OneStageBoss(OneStageBossState bossState, GameObject normalBullet, GameObject skillBullet)
    {
        this.bossState = bossState;
        this.normalBullet = normalBullet;
        this.skillBullet = skillBullet;

    }

    public void HandleState(string state)
    {
        switch(state)
        {
            case "AnnoyedState":
                bossState = new AnnoyedState(normalBullet, skillBullet);
                break;

            case "AngerState":
                bossState = new AngerState(normalBullet, skillBullet);
                break;

            default:
                break;
        }
    }
	
    public void Attack(GameObject boss)
    {
        bossState.Attack(boss);
    }

    public void Move()
    {
        bossState.Move();
    }

}
