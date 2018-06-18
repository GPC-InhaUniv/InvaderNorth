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
    public delegate void Decrease(GameObject player);
    public static Decrease DecreaseDelegate;
    [Header("GameObjcet")]
    public GameObject PlayerLife;
    public GameObject GameClearPopup;
    public GameObject GameOverPopup;
    [Header("Text")]
    public Text ScoreText;
    public Text ResourceText;
    [Header("Position")]
    public Vector3 SpawnValues;
    public PlayerSpawnPosition PlayerSpawnPosition;

    protected GameObject enemy;
    protected List<GameObject> playerLifeList;
    protected int scoreTotal;
    protected int playerLifePoint;
    protected bool hasBoss;

    void Start()
    {
        playerLifePoint = 3;// DataManager.Datainstance.gameData.hpLevel;
        SendScoreDelegate = AddScore;
        DecreaseDelegate = HeartDecrease;
        Vector3 PlayerLifePosition = PlayerLife.transform.position;
        playerLifeList = new List<GameObject>();
        for (int i = 0; i < playerLifePoint; i++)
        {
            if (i <= 5)
            {
                playerLifeList.Add(Instantiate(PlayerLife, PlayerLifePosition, PlayerLife.transform.rotation));
                PlayerLifePosition = new Vector3(PlayerLifePosition.x + 0.55f, 0, 14.45f);
            }
            else if (i == 6)
            {
                PlayerLifePosition = new Vector3(PlayerLife.transform.position.x, 0, 13.95f);
                playerLifeList.Add(Instantiate(PlayerLife, PlayerLifePosition, PlayerLife.transform.rotation));
                PlayerLifePosition = new Vector3(PlayerLifePosition.x + 0.55f, 0, 13.95f);
            }
            else
            {
                playerLifeList.Add(Instantiate(PlayerLife, PlayerLifePosition, PlayerLife.transform.rotation));
                PlayerLifePosition = new Vector3(PlayerLifePosition.x + 0.55f, 0, 13.95f);
            }
        }
        UpdateScore();
        StartCoroutine(StagePrograss());
    }


    protected abstract IEnumerator StagePrograss();
   

    void AddScore(int ScoreNumber, bool isBoss)
    {
        if(!IsGameClear && !IsGameOver)
            scoreTotal += ScoreNumber;
        UpdateScore();
        if (isBoss)
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
        IsGameOver = true;
        Debug.Log("GameOver");
    }

    void Clear()
    {
        GameClearPopup.SetActive(true);
        GameClearPopup.transform.Find("Score Text").gameObject.GetComponent<Text>().text = "획득 점수 -> " + scoreTotal.ToString();
        IsGameClear = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>().enabled = false;
        Debug.Log("GameClear");
    }
    
    public void OnClickedReStartButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void OnClickedGameOverLobbyButton()     //게임오버 로비버튼클릭 시 씬 전환.
    {
        Destroy(GameObject.Find("Enemys"));
        Destroy(GameObject.Find("PlayerBullets"));
        Destroy(GameObject.Find("EnemyBullets"));
        Destroy(GameObject.Find("ObjectPool"));
        SceneManager.LoadScene("LobbyScene");
    }


}
