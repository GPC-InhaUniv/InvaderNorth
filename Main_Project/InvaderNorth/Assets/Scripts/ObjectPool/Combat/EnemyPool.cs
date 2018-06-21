using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

    [SerializeField]
    private int NumberOfCommonEnemyCreation;
    [SerializeField]
    private GameObject Parent;
    private int stage;                           //스테이지 구분(임시)
    private List<Queue<GameObject>> enemyPoolList;
    private GameObject temp;                   //임시 담기용

    void Start ()
    {   
        GameObject commonEnemy;               // 몬스터 프리팹
        enemyPoolList = new List<Queue<GameObject>>();
        switch (stage)
        {
            case 0 :          //튜토리얼               
                enemyPoolList.Add(new Queue<GameObject>());
                commonEnemy = Resources.Load("Prefabs/NormalEnemy") as GameObject;            
                for (int i = 0; i < NumberOfCommonEnemyCreation; i++)
                {
                    temp = Instantiate(commonEnemy);
                    temp.transform.parent = Parent.transform;
                    enemyPoolList[0].Enqueue(temp);                    
                }

                DontDestroyOnLoad(Parent);
                break;

            case 1:           // 첫번째 스테이지
                enemyPoolList.Add(new Queue<GameObject>());
                commonEnemy = Resources.Load("Prefabs/NormalEnemy") as GameObject;
                for (int i = 0; i < NumberOfCommonEnemyCreation; i++)
                {
                    temp = Instantiate(commonEnemy);
                    temp.transform.parent = Parent.transform;
                    enemyPoolList[0].Enqueue(temp);
                }
                /* 여기다가 다른 몬스터 추가 
                enemyPoolList.Add(new Queue<GameObject>());
                for (int i = 0; i < NumberOfCommonEnemyCreation; i++)
                {
                    Temp = Instantiate(commonEnemy);
                    Temp.transform.parent = Parent.transform;
                    enemyPoolList[1].Enqueue(Temp);
                }
                 */

                DontDestroyOnLoad(Parent);
                break;
        }
    }

    public GameObject PopFromPool(int queueNum)
    {
        return enemyPoolList[queueNum].Dequeue(); 
    }

    public void PushToPool(GameObject enemy)
    { 
        enemy.SetActive(false);
        enemyPoolList[enemy.GetComponent<EnemyController>().queueNum].Enqueue(enemy);
    }

}
