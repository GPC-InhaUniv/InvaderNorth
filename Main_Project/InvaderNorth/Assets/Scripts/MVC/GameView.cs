using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour {

    [Header("SignSceneAttribute")]
    [SerializeField]
    private GameObject messagePopUpPanel;
    [SerializeField]
    private Text messagePopUpPanelText;
    [SerializeField]
    private Text signUpErrorMessageText;
    [SerializeField]
    private Text signUpSuccessMessageText;
    [SerializeField]
    private GameObject signUpErrorPopUp;

    [Header("LoadingSceneAttribute")]
    [SerializeField]
    private Text loadingSceneText;
    [SerializeField]
    private Slider loadingSceneSlider;

    [Header("LobbySceneAttribute")]


    [Header("CombatSceneAttribute")]


    [Header("GameViewPrivateAttribute")]
    private StageType currentStageType;
    public bool isLoadingFinished;
    
    //Sign Scene 메소드 영역
    public void ShowPopUp(string message)
    {
        messagePopUpPanel.SetActive(true);
        messagePopUpPanelText.text = message;
    }

    public void ShowSignUpSuccessMessage()
    {
        signUpSuccessMessageText.gameObject.SetActive(true);
    }

    public void ShowSignUpErrorMessage()
    {
        signUpErrorMessageText.gameObject.SetActive(true);
    }

    public void HideSignUpErrorMessage()
    {
        signUpErrorMessageText.gameObject.SetActive(false);
    }


    //Loading Scene 메소드 영역


    //Lobby Scene 메소드 영역


    //Stage 전환 시 애니메이션 효과
    private IEnumerator ChangeLoadingTextColor()
    {
        Color textColorPerFrame = loadingSceneText.color;

        while(isLoadingFinished)
        {
            yield return null;
        }
    }
}
