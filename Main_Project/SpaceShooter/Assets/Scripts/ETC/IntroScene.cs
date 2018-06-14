using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScene : MonoBehaviour {

    public GameObject panel;
    public Text polarisText;
    public Image polarisLogo;
    public Image inhaUnivLogo;
    private const int MaxFrame = 120;

	void Start () {
        StartCoroutine(IntroFadeOnOff());	
	}
	
    IEnumerator IntroFadeOnOff()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);

        asyncOperation.allowSceneActivation = false;

        int frameCount = 0;

        while (frameCount < MaxFrame * 3)
        {
            Color color = panel.GetComponent<Image>().color;

            if(frameCount < 60)
            {
                color.a -= 1.0f / 60.0f;
            }
            else if(frameCount < 180 && frameCount > 120)
            {
                color.a += 1.0f / 60.0f;
            }
            else if(frameCount == 180)
            {
                polarisText.enabled = false;
                polarisLogo.enabled = false;
                inhaUnivLogo.gameObject.SetActive(true);
            }
            else if(frameCount < 240 && frameCount > 180)
            {
                color.a -= 1.0f / 60.0f;
            }
            else if(frameCount > 300)
            {
                color.a += 1.0f / 60.0f;
            }
            panel.GetComponent<Image>().color = color;
            frameCount++;
            
            yield return new WaitForSeconds(0.03f);
        }

        asyncOperation.allowSceneActivation = true;


    }
}
