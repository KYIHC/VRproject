using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float destroyInterval;
    
    public void Start()
    {
        destroyInterval = PlayerPrefs.GetFloat("destroyInterval");

        Destroy(gameObject, destroyInterval);
        
    }    


}
