using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyName     //몬스터를 구별하여 패턴을 지정하기 위해 사용.
{
    NormalEnemy, 
    TutorialBoss,
    HorizontalMovingEnemy,
    MultiShotEnemy,   
    FirstNamed,
    SecondNamed,
}

public class EnemyController : MonoBehaviour {
    public int queueNum;
    [SerializeField]
    private float skillCoolTime;       //스킬 사용의 텀을 두기 위해.
    [SerializeField]
    private float attackCoolTime;      //공격의 텀을 두기 위해.
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

            case EnemyName.TutorialBoss:
                enemy = new TutorialBoss(GetComponent<Rigidbody>());
                break;

            case EnemyName.MultiShotEnemy:
                enemy = new MultiShotEnemy(GetComponent<Rigidbody>());
                break;

            case EnemyName.HorizontalMovingEnemy:
                enemy = new HorizontalMovingEnemy(GetComponent<Rigidbody>());
                break;

            case EnemyName.FirstNamed:
                enemy = new FirstNamed(GetComponent<Rigidbody>());
                break;

            case EnemyName.SecondNamed:
                enemy = new SecondNamed(GetComponent<Rigidbody>());
                break;
        }
        StartCoroutines();
    }

    void OnEnable()                  //활성화 시 호출되는 함수.
    {
;       if(enemy != null)           //처음에는 실행 안되게
        {
            StartCoroutines();
        }    
    }

    IEnumerator Attack()             //공격
    {
        while (true)
        {
            if (StageController.IsGameClear || StageController.IsGameOver)
                break;
            enemy.Attack(gameObject);
            shotAudio.Play();          
            yield return new WaitForSeconds(attackCoolTime);
        }
    }

    IEnumerator SkillUse()
    {
        yield return new WaitForSeconds(1);
        while(true)
        {
            if (StageController.IsGameClear || StageController.IsGameOver)
                break;
            enemy.SkillUse(gameObject);
            shotAudio.Play();
            yield return new WaitForSeconds(skillCoolTime);
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

    public void StartCoroutines()
    {
        if (attackCoolTime != 0)
            StartCoroutine(Attack());
        if (skillCoolTime != 0)
            StartCoroutine(SkillUse());
        StartCoroutine(Move());
    }





}
