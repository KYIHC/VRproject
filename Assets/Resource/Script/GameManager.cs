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
    public GameObject AddGrenPanel;
    public GameObject AddGrenCircle;
    public GameObject grenadeSpwan;

    public GameObject grenadePrefab;


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

    /*public void AddGrenadeButton()
    {
        startPanel.SetActive(false);
        startCircle.SetActive(false);
        AddGrenPanel.SetActive(true);
        AddGrenCircle.SetActive(true);

    }*/


    public void SelectDifficulty(int Difficulty)
    {
        float spwanInterval = Difficulty == 1 ? 3f : Difficulty == 2 ? 2f : 1f;
        float destroyInterval = Difficulty == 1 ? 5f : Difficulty == 2 ? 4f : 3f;

        PlayerPrefs.SetFloat("spwanInterval", spwanInterval);
        PlayerPrefs.SetFloat("destroyInterval", destroyInterval);

        difficultyPanel.SetActive(false);
        difficultyCircle.SetActive(false);

        spwanControll.StartCoroutine(spwanControll.SpwanObject());

    }

    public void AddGrenade()
    {
        Vector3 SpwanPosition =  Random.insideUnitSphere * 0.5f;
        SpwanPosition = new Vector3(SpwanPosition.x, 0, SpwanPosition.y);
        Vector3 GrenadeSpwanPosition = grenadeSpwan.transform.position + SpwanPosition;

               Instantiate(grenadePrefab, GrenadeSpwanPosition, grenadeSpwan.transform.rotation);
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
