using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum StageType
{
    IntroStage = 0,
    SignStage = 1,
    LobbyStage = 2,
    ShopStage = 3,
    TutorialStage = 4,
    CombatStage = 5,
    LoadingStage = 6
}

public class StageManager : MonoBehaviour
{
    public static StageManager stageInstance;

    void Start ()
    {
        stageInstance = this;
        DontDestroyOnLoad(gameObject);
	}

    public void ChangeStageIntroToLobby(StageType stageType)
    {
        StartCoroutine(ChangeStageCoroutine(stageType));
    }

    IEnumerator ChangeStageCoroutine(StageType stageType)
    {
        AsyncOperation loadoperation = SceneManager.LoadSceneAsync((int)StageType.LoadingStage);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)stageType);

        asyncOperation.allowSceneActivation = false;

        int frameCount = 30;

        while(!asyncOperation.isDone && frameCount > 0)
        {
            frameCount--;
            yield return new WaitForSeconds(0.03f);
        }

        asyncOperation.allowSceneActivation = true;
    }
}
