using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputGrenade : MonoBehaviour
{
    public GameObject grenade;

    public void GrenadeButtonRActivate(InputAction.CallbackContext context)
    {
        
        Debug.Log("gren");
       /* if(gameObject.name=="Grenade")
        {
            grenade.GetComponent<Rigidbody>().AddForce(transform.forward * 10f ,ForceMode.Impulse);
        }*/


    }
}
