using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public LayerMask targetLayer;

    public GameObject bullet;



    private void OnTriggerEnter(Collider other)
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if ((targetLayer | (1 << other.gameObject.layer)) == targetLayer)
        {

            Destroy(gameObject);

            Destroy(other);


            gameManager.GetScore();
            gameManager.MinusEnemy();



        }
    }


}
