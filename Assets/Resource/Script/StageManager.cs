using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject Soldier;
    public GameObject Stage;
    public GameObject NextStage;

    private void Update()
    {
        nextStage();
    }

    public void nextStage()
    {
        
            /*GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            if (gameManager.CountEnemy() == 0)
            {
                Stage.SetActive(false);
                NextStage.SetActive(true);
            }*/

        if(Soldier==null)
        {
            Stage.SetActive(false);
            NextStage.SetActive(true);
        }
            
        
    }

}
