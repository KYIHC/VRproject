using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Projectile")
        {
            GameManager.Instance.onStartButton();
        }
        Destroy(other);
    
    }
}
