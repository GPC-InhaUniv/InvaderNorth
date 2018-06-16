using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct PlayerSpawnPosition
{
    public float x, z;
}

public class TutorialController : MonoBehaviour
{
    public delegate void SendScore(int Score , bool isBoss);
    public static SendScore SendScoreDelegate;
    public delegate void Decrease(GameObject player);
    public static Decrease DecreaseDelegate;

    public PlayerSpawnPosition PlayerSpawnPosition;
    [Header ("GameObjcet")]
    public GameObject TutorialSprite;
    public GameObject PlayerLife;
    public GameObject GameClearPopup;
    public GameObject GameOverPopup;

    [Header("Text")]
    public Text ScoreText;
    public Text ResourceText;

    [Header("Vector")]
    public Vector3 SpawnValues;

    GameObject enemy;
    List<GameObject> playerLifeList;
    int scoreTotal;
    int playerLifePoint;
    bool isGameOver;
    bool isGameClear;

    void Start()
    {
        playerLifePoint = 3;//DataManager.Datainstance.gameData.hpLevel;
        SendScoreDelegate = AddScore;
        DecreaseDelegate = HeartDecrease;
        Vector3 heartPosition = PlayerLife.transform.position;
        playerLifeList = new List<GameObject>();
        for(int i = 0; i < playerLifePoint; i ++)
        {
            if (i <= 5)
            {
                playerLifeList.Add(Instantiate(PlayerLife, heartPosition, PlayerLife.transform.rotation));
                heartPosition = new Vector3(heartPosition.x + 0.55f, 0, 14.45f);
            }else if(i == 6)
            {
                heartPosition = new Vector3(PlayerLife.transform.position.x , 0, 13.95f);
                playerLifeList.Add(Instantiate(PlayerLife, heartPosition, PlayerLife.transform.rotation));
                heartPosition = new Vector3(heartPosition.x + 0.55f, 0, 13.95f);
            }
            else
            {
                playerLifeList.Add(Instantiate(PlayerLife, heartPosition, PlayerLife.transform.rotation));
                heartPosition = new Vector3(heartPosition.x + 0.55f, 0, 13.95f);
            }
        }
        UpdateScore();
        StartCoroutine(tutorialPrograss());
    }

    IEnumerator tutorialPrograss()
    {
        bool hasBoss = false;
        yield return new WaitForSeconds(3);
        Destroy(TutorialSprite);
        while(true)
        {
            if (scoreTotal >= 300 && hasBoss == false)
            {
                enemy = ObjectPoolManager.PoolManager.EnemyPool.PopFromPool("TutorialBoss");
                enemy.SetActive(true);
                hasBoss = true;
            }
            enemy = ObjectPoolManager.PoolManager.EnemyPool.PopFromPool("NormalEnemy");
            enemy.transform.position = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
            enemy.SetActive(true);

            if (isGameClear)
                break;
            yield return new WaitForSeconds(2);
        }
        yield return null;
    }

    void AddScore(int ScoreNumber, bool isBoss)
    {
        scoreTotal += ScoreNumber;
        UpdateScore();
        if(isBoss)
        {
            Clear();
        }
    }

    void UpdateScore()
    {
        ScoreText.text = "Score : " + scoreTotal;
    }

    void HeartDecrease(GameObject player)
    {
        playerLifeList[playerLifePoint - 1].SetActive(false);
        playerLifePoint--;
        if (playerLifePoint > 0)
        {
            PlayerRespawn(player);
        }
        else
            GameOver();
            
    }

    void PlayerRespawn(GameObject player)
    {      
        player.transform.position = new Vector3(PlayerSpawnPosition.x, 0, PlayerSpawnPosition.z);
        player.SetActive(true);
        
    }

    void GameOver()
    {
        GameOverPopup.SetActive(true);
        GameOverPopup.transform.Find("Score Text").gameObject.GetComponent<Text>().text = "획득 점수 -> " + scoreTotal.ToString();
        isGameOver = true;
        Debug.Log("GameOver");
    }

    void Clear()
    {
        GameClearPopup.SetActive(true);
        GameClearPopup.transform.Find("Score Text").gameObject.GetComponent<Text>().text = "획득 점수 -> " + scoreTotal.ToString();
        isGameClear = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>().enabled = false;
        Debug.Log("GameClear");
    }

}
