using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    public bool HasFirstStart;
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

        if (HasFirstStart == true)
        {
             ao = SceneManager.LoadSceneAsync(5);
        }else
        {
             ao = SceneManager.LoadSceneAsync(4);
        }
        ao.allowSceneActivation = false;
        
        yield return new WaitForSeconds(0.1f);

        ao.allowSceneActivation = true;

    }
}
