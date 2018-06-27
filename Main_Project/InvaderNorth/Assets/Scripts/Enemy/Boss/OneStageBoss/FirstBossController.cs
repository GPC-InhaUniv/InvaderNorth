using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossController : MonoBehaviour {
    [SerializeField]
    private float attackCoolTime;
    private int maxBossHealthPoint;
    private float stateHandleNum;
    private FirstBoss boss;
    private Rigidbody rigidbody;
    private Animator animator;
    

    NamedEnemyCollision namedEnemyCollision;
	private void Start ()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);
        namedEnemyCollision = GetComponent<NamedEnemyCollision>();
        maxBossHealthPoint = namedEnemyCollision.getHealthPoint();
        rigidbody = GetComponent<Rigidbody>();
        boss = new FirstBoss(new NormalState(rigidbody), rigidbody);
        StartCoroutine(Move());
        StartCoroutine(Attack());
    }

    private void Update()
    {
        if (namedEnemyCollision.getHealthPoint() <= maxBossHealthPoint * 2/3 && stateHandleNum == 0)
        {
            boss.HandleState("AnnoyedState");
            stateHandleNum++;
            StartCoroutine(SkillOne());
        }
        else if(namedEnemyCollision.getHealthPoint() <= maxBossHealthPoint  / 3 && stateHandleNum == 1)
        {
            boss.HandleState("AngerState");
            animator.SetBool("Attack", false);
            animator.SetBool("Skill", true);
            attackCoolTime -= 0.2f;
            stateHandleNum++;
        }

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("Run", false);
        animator.SetBool("Attack", true);
        while (true)
        {
            if (StageController.IsGameClear || StageController.IsGameOver)
                break;     
            boss.Attack(gameObject);
            SoundManager.instance.PlaySoundType(SoundType.EnmeyShot);
            yield return new WaitForSeconds(attackCoolTime);
        }
    }
    
    IEnumerator Move()
    {
        while (true)
        {
            boss.Move(gameObject);
            yield return null;
        }
    }

    IEnumerator SkillOne()
    {
        yield return new WaitForSeconds(1);
        while(true)
        {
            if (StageController.IsGameClear || StageController.IsGameOver)
                break;
            boss.SkillUse(gameObject);
            SoundManager.instance.PlaySoundType(SoundType.EnmeyShot);
            yield return new WaitForSeconds(1f);
            if (namedEnemyCollision.getHealthPoint() <= maxBossHealthPoint / 3)
                break;
        }
        yield return null;
    }

}
