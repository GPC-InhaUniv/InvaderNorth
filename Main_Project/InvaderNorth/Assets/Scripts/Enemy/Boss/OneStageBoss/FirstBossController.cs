using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossController : MonoBehaviour {
    [SerializeField]
    private float attackCoolTime;
    private float Timer;
    private FirstBoss boss;
    private Rigidbody rigidbody;
    

    NamedEnemyCollision namedEnemyCollision;
	void Start ()
    {
        namedEnemyCollision = GetComponent<NamedEnemyCollision>();
        rigidbody = GetComponent<Rigidbody>();
        boss = new FirstBoss(new NormalState(rigidbody), rigidbody);
        StartCoroutine(Attack());
	}
	
    IEnumerator Attack()
    {
        Debug.Log("start");
        while(true)
        {
            boss.Attack(gameObject);
            yield return new WaitForSeconds(attackCoolTime);
            if (transform.position.z <= 12)
            {
                Debug.Log("break");
                break;
            }
        }
        yield return StartCoroutine(SkillOne());
    }

    IEnumerator SkillOne()
    {
        Debug.Log("SkillOne");
        yield return new WaitForSeconds(1);
        Debug.Log("SkillOneeee");
    }

    IEnumerator PatternThree()
    {
        yield return null;
    }



}
