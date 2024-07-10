using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class XRCustumCotroller : MonoBehaviour
{
    public InputActionReference bButton;
    public GunFire gunFire;
    

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        bButton.action.performed += delegate(InputAction.CallbackContext ctx)
        {
            gunFire.Reload(ctx.performed);
        };
        

     
    }

}
