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



    public void onStartButton()
    {

       SpwanControll spwanControll = GameObject.Find("GameManager").GetComponent<SpwanControll>();
        StartCoroutine(spwanControll.SpwanObject());
    }

    private void Update()
    {
        Score.text = score.ToString();
        Enemy.text = enemy.ToString();
    }

    public void GetScore()
    {
        score++;

    }
    public void MinusEnemy()
    {
        enemy--;
    }
}
