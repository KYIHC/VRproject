using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficulty : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {              

        if ((other.gameObject.tag == "Projectile"))
        {
            /*spwanInterval = gameObject.name=="easy" ? 3f : 
                            gameObject.name == "normal" ? 2f :
                            1f;
            destroyInterval = gameObject.name == "easy" ? 5f :
                            gameObject.name == "normal" ? 3f :
                            1f;
            
            PlayerPrefs.SetFloat("spwanInterval", spwanInterval);
            PlayerPrefs.SetFloat("destroyInterval", destroyInterval);

            

            GameManager.Instance.difficultyPanel.SetActive(false);            
            GameManager.Instance.spwanControll.StartCoroutine("SpwanObject");
            
            gameObject.transform.parent.gameObject.SetActive(false);*/

            int difficulty = gameObject.name == "easy" ? 1 :
                            gameObject.name == "normal" ? 2 :
                            3;
            GameManager.Instance.SeletDifficulty(difficulty);
        }
    }
}
