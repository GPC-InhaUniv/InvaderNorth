using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum StageType
{
    IntroStage,
    SignStage,
    LobbyStage,
    ShopStage,
    CombatStage
}

public class StageManager : MonoBehaviour
{
    public static StageManager stageInstance;

    void Start ()
    {
        stageInstance = this;
        DontDestroyOnLoad(gameObject);
	}

    public void ChangeStageIntroToLobby()
    {
        StartCoroutine(ChangeStageCoroutine());
    }

    IEnumerator ChangeStageCoroutine()
    {
        AsyncOperation loadoperation = SceneManager.LoadSceneAsync(2);
        
        while(!loadoperation.isDone)
        {
            yield return null;
        }

        //loadoperation = SceneManager.LoadSceneAsync(2);

    }
}
