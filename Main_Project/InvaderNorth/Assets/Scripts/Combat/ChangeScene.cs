using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    [SerializeField]
    private bool hasFirstStart;
    AsyncOperation ao;

    // Use this for initialization
    void Start () {
        StartCoroutine(LoadMain());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LoadMain()
    {
        if (hasFirstStart == true)
        {
             ao = SceneManager.LoadSceneAsync("TutorialScene");
        }else
        {
             ao = SceneManager.LoadSceneAsync("CombatScene");
        }
        ao.allowSceneActivation = false;
        
        yield return new WaitForSeconds(0.1f);

        ao.allowSceneActivation = true;

    }
}
