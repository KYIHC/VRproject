using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    /*public ParticleSystem explosionParticle;*/

    public float explosionRadius = 20f;
    public float explosionTime=5f;
    
    private bool isExplosion = false;



    public void isGren()
    {
        if(isExplosion)
        {
            return;
        }
        isExplosion = true;

        Invoke("Bomb", explosionTime);
        
    }
    private void Bomb()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider obj in colliders)
        {
            if(obj.gameObject.tag=="soldier")
            {
                obj.GetComponent<Rigidbody>().AddExplosionForce(300f, transform.position, 20f, 20f);
                /*ParticleSystem ExplosionParticle = Instantiate(explosionParticle, transform.position, transform.rotation);*/

                Destroy(obj.gameObject, 0.5f);
                
            }
        }
        





        Destroy(gameObject);

    }
    
    


}
