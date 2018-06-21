using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyName     //몬스터를 구별하여 패턴을 지정하기 위해 사용.
{
    NormalEnemy, 
    MultiShotEnemy,
}

public class EnemyController : MonoBehaviour {
    public int queueNum;
    [SerializeField]
    private float skillCoolTime;       //스킬 사용의 텀을 두기 위해.
    [SerializeField]
    private EnemyName enemyName ;
    private Enemy enemy;
    private AudioSource shotAudio;

    void Start ()
    {
        shotAudio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().Play();
        switch (enemyName)             //구별하여 패턴을 지정.
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
            shotAudio.Play();
            yield return new WaitForSeconds(skillCoolTime);
            if (skillCoolTime > 0)
            {
                enemy.SkillUse(gameObject);
                shotAudio.Play();
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
