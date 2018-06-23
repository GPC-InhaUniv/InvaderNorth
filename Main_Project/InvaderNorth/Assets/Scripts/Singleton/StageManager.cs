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
    private StageType currentStage;

    public static StageManager stageInstance;

    public delegate void SceneChangedDelegate(StageType stageType);
    public SceneChangedDelegate sceneChangedCallBack;

    public delegate void LoadStageDeleagate();


    void Awake()
    {
        currentStage = StageType.IntroStage;
        stageInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator ChangeStageCoroutine(StageType stageType)
    {
        if(currentStage == StageType.IntroStage)
        {
            SceneManager.LoadSceneAsync((int)stageType);
            currentStage = stageType;
        }
        else if (currentStage == StageType.ShopStage && stageType == StageType.LobbyStage ||
                 currentStage == StageType.LobbyStage && stageType == StageType.ShopStage)
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync((int)stageType);
            currentStage = stageType;

            yield return loadOperation;

            sceneChangedCallBack(stageType);

        }

        else
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync((int)StageType.LoadingStage);
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)stageType);
            
            asyncOperation.allowSceneActivation = false;

            int frameCount = 30;
            currentStage = stageType;


            while (frameCount > 0)
            {
                frameCount--;
                yield return new WaitForSeconds(0.03f);
            }

            asyncOperation.allowSceneActivation = true;

            yield return asyncOperation;

            sceneChangedCallBack(stageType);
        }
    }
}
