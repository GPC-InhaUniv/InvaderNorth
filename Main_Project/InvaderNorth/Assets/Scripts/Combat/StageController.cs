using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[System.Serializable]
public struct PlayerSpawnPosition
{
    public float x, z;
}

public abstract class StageController : MonoBehaviour {

    public static bool IsGameOver;
    public static bool IsGameClear;
    public delegate void SendScore(int Score, bool isBoss);
    public static SendScore SendScoreDelegate;
    public delegate void SendCredit();
    public static SendCredit SendCreditDelegate;
    public delegate void Decrease(GameObject player);
    public static Decrease DecreaseDelegate;
    [Header("GameObjcet")]
    [SerializeField]
    private GameObject playerLife;
    [SerializeField]
    private GameObject gameClearPopup;
    [SerializeField]
    private GameObject gameOverPopup;
    [SerializeField]
    protected GameObject bossEnemy;
    [Header("Text")]
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text creditText;
    [Header("Position")]
    [SerializeField]
    private PlayerSpawnPosition playerSpawnPosition;
    [SerializeField]
    protected Vector3 spawnValues;

    protected GameObject enemy;
    protected List<GameObject> playerLifeList;
    protected int scoreTotal;
    protected int playerLifePoint;
    protected int creditTotal;
    protected bool hasBoss;

    void Start()
    {
        playerLifePoint = 2;// DataManager.Datainstance.gameData.hpLevel;
        SendScoreDelegate = AddScore;
        SendCreditDelegate = AddCredit;
        DecreaseDelegate = HeartDecrease;
        Vector3 PlayerLifePosition = playerLife.transform.position;
        playerLifeList = new List<GameObject>();
        for (int i = 0; i < playerLifePoint; i++)
        {
            if (i <= 5)
            {
                playerLifeList.Add(Instantiate(playerLife, PlayerLifePosition, playerLife.transform.rotation));
                PlayerLifePosition = new Vector3(PlayerLifePosition.x + 0.55f, 0, 14.45f);
            }
            else if (i == 6)
            {
                PlayerLifePosition = new Vector3(playerLife.transform.position.x, 0, 13.95f);
                playerLifeList.Add(Instantiate(playerLife, PlayerLifePosition, playerLife.transform.rotation));
                PlayerLifePosition = new Vector3(PlayerLifePosition.x + 0.55f, 0, 13.95f);
            }
            else
            {
                playerLifeList.Add(Instantiate(playerLife, PlayerLifePosition, playerLife.transform.rotation));
                PlayerLifePosition = new Vector3(PlayerLifePosition.x + 0.55f, 0, 13.95f);
            }
        }
        UpdateScore();
        StartCoroutine(StagePrograss());
    }

    protected abstract IEnumerator StagePrograss();
   
   /// <summary>
   /// 
   /// </summary>
   /// <param name="ScoreNumber"></param>
   /// <param name="isBoss"></param>

    void AddScore(int ScoreNumber, bool isBoss)
    {
        if(!IsGameClear && !IsGameOver)
            scoreTotal += ScoreNumber;
        UpdateScore();
        if (isBoss)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>().enabled = false;
            Invoke("GameClear", 2f);
        }
    }

    void AddCredit()
    {
        if (!IsGameClear)
            creditTotal++;
        UpdateCredit();
    }

    void UpdateScore()
    {
        scoreText.text = "Score : " + scoreTotal;
    }

    void UpdateCredit()
    {
        creditText.text = creditTotal.ToString();
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
        player.transform.position = new Vector3(playerSpawnPosition.x, 0, playerSpawnPosition.z);
        player.SetActive(true);

    }

    void GameOver() //요부분이 게임오버시 팝업 출력.
    {
        gameOverPopup.SetActive(true);
        gameOverPopup.transform.Find("Score Text").GetComponent<Text>().text = "획득 점수 -> " + scoreTotal.ToString();
        gameOverPopup.transform.Find("Credit Text").GetComponent<Text>().text = "획득 자원-> " + creditTotal.ToString();
        IsGameOver = true;
        Debug.Log("GameOver");
    }

    void GameClear() //요부분이 클리어시 팝업 출력
    {
        gameClearPopup.SetActive(true);  
        gameClearPopup.transform.Find("Score Text").GetComponent<Text>().text = "획득 점수 -> " + scoreTotal.ToString();
        gameClearPopup.transform.Find("Credit Text").GetComponent<Text>().text = "획득 자원-> " + creditTotal.ToString();
        IsGameClear = true;
        Debug.Log("GameClear");
    }

    void DestroyObjects()
    {
        Destroy(GameObject.FindGameObjectWithTag("ObjectPool"));
    }

    public void OnClickedReStartButton()           //게임오버 재시작버튼클릭 시 씬 전환.
    {
        IsGameOver = false;
        IsGameClear = false;
        DestroyObjects();
        SceneManager.LoadScene("CombatLoadingScene");
    }

    public void OnClickedGameOverLobbyButton()     //게임오버 로비버튼클릭 시 씬 전환.
    {
        DestroyObjects();
        SceneManager.LoadScene("LobbyScene");
    }


    

}
