using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Score;
    public Text Enemy;

    public int score = 0;
    public int enemy = 20;

    public GameObject startPanel;
    public GameObject startCircle;
    public GameObject difficultyPanel;
    public GameObject difficultyCircle;


    public SpwanControll spwanControll;

    private static GameManager instance = null;

    public void Awake()
    {
        if (startPanel != null &&
            startCircle != null &&
            difficultyPanel == null &&
            difficultyCircle != null)
        {

            startPanel.SetActive(true);
            startCircle.SetActive(true);
            difficultyPanel.SetActive(false);
            difficultyCircle.SetActive(false);
        }

        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }



    private void Update()
    {
        if (Score != null) { Score.text = score.ToString();}
        if(Enemy != null) {Enemy.text = enemy.ToString(); }
        
    }

    public void onStartButton()
    {
        startPanel.SetActive(false);
        startCircle.SetActive(false);
        difficultyPanel.SetActive(true);
        difficultyCircle.SetActive(true);

    }


    public void SeletDifficulty(int Difficulty)
    {
        float spwanInterval = Difficulty == 1 ? 3f : Difficulty == 2 ? 2f : 1f;
        float destroyInterval = Difficulty == 1 ? 5f : Difficulty == 2 ? 4f : 3f;

        PlayerPrefs.SetFloat("spwanInterval", spwanInterval);
        PlayerPrefs.SetFloat("destroyInterval", destroyInterval);

        difficultyPanel.SetActive(false);
        difficultyCircle.SetActive(false);

        spwanControll.StartCoroutine(spwanControll.SpwanObject());

    }


    public void GetScore()
    {
        score++;

    }
    public void MinusEnemy()
    {
        enemy--;
    }
    public int CountEnemy()
    {
        return enemy;
    }
}
