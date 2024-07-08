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
        SceneManager.LoadScene("loadingScene");

    }
    public void QuitGame()
    {
        
        Application.Quit(); 

    }

}
