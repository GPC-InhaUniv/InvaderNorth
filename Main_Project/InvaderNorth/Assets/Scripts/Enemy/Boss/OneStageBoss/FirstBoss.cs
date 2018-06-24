using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss 
{
    private FirstBossState bossState;
    private Rigidbody rigidbody;


    public FirstBoss(FirstBossState bossState, Rigidbody rigidbody)
    {
        this.bossState = bossState;
        this.rigidbody = rigidbody;
    }

    public void HandleState(string state)
    {
        switch(state)
        {
            case "AnnoyedState":
                bossState = new AnnoyedState(rigidbody);
                break;

            case "AngerState":
                bossState = new AngerState(rigidbody);
                break;

            default:
                break;
        }
    }
	
    public void Attack(GameObject boss)
    {
        bossState.Attack(boss);
    }

    public void Move(GameObject boss)
    {
        bossState.Move(boss);
    }

}
