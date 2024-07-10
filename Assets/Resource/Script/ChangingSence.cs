using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class ChangingSence : MonoBehaviour
{
    public Slider progressbar;
    public Text loadingText;

    private void Start()
    {
        //현재 씬이 LoadingScene이면
        if(SceneManager.GetActiveScene().name == "LoadingScene")
        {
            StartCoroutine(LoadScene());
        }
    }

    /* 
     
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
     }*/

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("lastLoadedScene"));
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            if (progressbar.value<1f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }            
            else
            {
                loadingText.text = " 로딩 완료";

            }

            yield return new WaitForSeconds(2f);
            operation.allowSceneActivation = true;
        }

    }

}
