using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //여러 종류의 운석을 생성하기 위한 배열
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float wavewait;

    private bool gameOver;
    private bool restart;
    private int score;

    private void Start()
    {
            //스타트 코루틴(시그니쳐는 괄호안에) --> 운석 랜덤생성 (한번에 생성되는 것이 아닌 하나씩 여러번 생성되게 생성딜레이 만들기)
        StartCoroutine(SpawnWaves());
    }

    //코루틴을 사용하려면 IEnumerator를 반환해야함
    IEnumerator SpawnWaves()
    {
        //startwait를 설정하기(코루틴)
        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < hazardCount; i++)
        {
            //hazards 는 배열공간일 뿐이므로 각각의 객체를 새로 생성해야 함
            GameObject hazard = hazards[Random.Range(0, hazards.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            //코루틴 사용하려면 다음과 같이 작성해야함
            yield return new WaitForSeconds(spawnWait);
        }
        yield return new WaitForSeconds(wavewait);
    }
       
       
   
    //DestoryByContect 스크립트에서 호출함. --> 호출계층구조로 확인하면 쉬움
    
   
}
