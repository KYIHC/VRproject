using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangingSence : MonoBehaviour
{
    public void ChangeSence(string senceName)
    {
        PlayerPrefs.SetString("lastLoadedScene", senceName);
        SceneManager.LoadScene("LoadingScene");

    }
    public void QuitGame()
    {
        
        Application.Quit(); 
        //플레이모드 종료

    }

    public void LoadLastScene()
    {
        string lastLoadedScene = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(lastLoadedScene);
    }

    private void Update()
    {
        //현재씬이 로딩씬이면
        if (SceneManager.GetActiveScene().name == "LoadingScene")
        {

            LoadLastScene();
        }
    }

}
