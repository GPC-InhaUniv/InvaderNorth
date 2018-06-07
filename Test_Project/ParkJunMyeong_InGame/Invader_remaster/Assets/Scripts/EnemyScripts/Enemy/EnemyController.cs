using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyName     //몬스터를 구별하여 패턴을 지정하기 위해 사용.
{
    NormalEnemy, 
    MultiShotEnemy,
}

public class EnemyController : MonoBehaviour {
    public float SkillCoolTime;       //스킬 사용의 텀을 두기 위해.
    public EnemyName enemyName ;      
    Enemy enemy;


    void Start ()
    {
        switch(enemyName)             //구별하여 패턴을 지정.
        {
            case EnemyName.NormalEnemy:
                enemy = new NormalEnemy();
                break;

            case EnemyName.MultiShotEnemy:
                enemy = new MultiShotEnemy();
                break;

        }
        StartCoroutine(Base());
        StartCoroutine(Move());
    }

    void OnEnable()                  //활성화 시 호출되는 함수.
    {
        if(enemy != null)           //처음에는 실행 안되게
        {
            StartCoroutine(Base());
            StartCoroutine(Move());
        }    
    }
 



    IEnumerator Base()             //공격
    {
        
        while (true)
        {
            enemy.Attack(gameObject);
            yield return new WaitForSeconds(SkillCoolTime);
            enemy.SkillUse(gameObject);
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator Move()             //이동
    {
        while(true)
        {
            enemy.Move(gameObject);
            yield return new WaitForSeconds(2);
        }
        
    }







}
