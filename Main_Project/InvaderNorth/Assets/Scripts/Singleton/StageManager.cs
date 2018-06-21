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

    public delegate void SceneChanged(StageType stageType);
    public SceneChanged sceneChangedCallBack;

    void Awake()
    {
        stageInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator ChangeStageCoroutine(StageType stageType)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync((int)StageType.LoadingStage);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)stageType);

        asyncOperation.allowSceneActivation = false;

        int frameCount = 30;

        while(!asyncOperation.isDone && frameCount > 0)
        {
            frameCount--;
            yield return new WaitForSeconds(0.03f);
        }

        sceneChangedCallBack(stageType);

        asyncOperation.allowSceneActivation = true;
    }
}
