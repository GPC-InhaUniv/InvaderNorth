using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class DestroyByContect : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int ScoreValue;
    private GameController gameController;
    
    private void Start()
    {
        //GameController를 찾아서 gameControllerObject릐 초기값으로 설정해준다.
        //--> 인스펙터상에서 탬플릿이 인스턴스를 참조하는것이 안되기 때문에
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        //gameControllerObject를 성공적으로 찾았다면 
        if(gameControllerObject != null)
        {
            //gameControllerObject에 대한 레퍼런스를 테스트하여 이상이 없는지 확인한다.
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        //만약 gameController가 null일 경우 Debug.Log를 호출하여 콘솔에서 알린다. (보험)
        if(gameControllerObject == null)
        {
            Debug.Log("GameControllerScript를 찾을 수 없습니다.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boundary")||other.CompareTag("Enemy")) //tag설정을 하여 string형식으로 스크립트에서 받아온다.
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag=="player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(ScoreValue); 
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    

    
}
