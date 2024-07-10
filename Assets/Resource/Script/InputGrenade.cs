using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputGrenade : MonoBehaviour
{
    Grenade gren;
    public Transform Controller;

    
    

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
        yield return new WaitForSeconds(0f);
        gren.GetComponent<Rigidbody>().AddForce(Controller.transform.forward * 10f, ForceMode.Impulse);
    }
    
}
