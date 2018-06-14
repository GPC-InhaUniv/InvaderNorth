using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void ToNextScene()
    {
        SceneManager.LoadScene("대기화면");
    }
}
