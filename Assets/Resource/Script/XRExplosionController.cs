/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class XRExplosionController : MonoBehaviour
{
    
    public InputActionReference exButton;
    public InputGrenade gren;
    public bool isGreb=false;
    public InputActionReference grebButton;


    public void Greb()
    {
        if(isGreb)
        {
            return;
        }
        
        isGreb = true;
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        if (isGreb == true)
        {
            exButton.action.performed += delegate (InputAction.CallbackContext context)
              {
                  Debug.Log("¡ÿ∫Ò");
                  gren.grenShot(context.performed);
              };
        }

     
    }

}*/
