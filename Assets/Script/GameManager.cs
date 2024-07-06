using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void onStartButton()
    {

       SpwanControll spwanControll = GameObject.Find("GameManager").GetComponent<SpwanControll>();
        StartCoroutine(spwanControll.SpwanObject());
    }
}
