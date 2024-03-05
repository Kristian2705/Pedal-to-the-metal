using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public void OnLoadGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnExitGame()
    {
        Debug.Log("Exit Game");
    }
}
