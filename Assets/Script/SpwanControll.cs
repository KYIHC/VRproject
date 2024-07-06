using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanControll : MonoBehaviour
{

    public GameObject spwanObject;
    public GameObject player;

    public IEnumerator SpwanObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            Vector3 spwanPoint = new Vector3(Random.Range(-8, 2), 0, Random.Range(-11, 11));

            GameObject spwanedObject = Instantiate(spwanObject, spwanPoint, Quaternion.identity);

            // 오브젝트는 플레이어를 바라봄

            spwanedObject.transform.LookAt(player.transform);
        }


    }

    public void Start()
    {
        
    }


}
