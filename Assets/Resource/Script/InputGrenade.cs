using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputGrenade : MonoBehaviour
{
    Grenade gren;
    GameObject controller;

    private void Start()
    {
        gren = GetComponent<Grenade>();
    }

    public void grenShot()
    {
        StartCoroutine(grenThrow());
        
    }
    IEnumerator grenThrow()
    {
        yield return null;
        gren.GetComponent<Rigidbody>().AddForce(controller.transform.forward * 10f, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            controller = other.gameObject;
        }
   
    }

}
