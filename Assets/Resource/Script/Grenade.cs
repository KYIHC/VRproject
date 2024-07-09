using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject particle;

    public float explosionRadius = 5f;
    public float explosionTime = 5f;
    AudioSource audioSource;
    public AudioClip exSound;
    InputGrenade inputgrenade;



    private bool isExplosion = false;





    public void isGren()
    {
        inputgrenade = GetComponent<InputGrenade>();
        inputgrenade.grenShot();

        if (isExplosion)
        {
            return;
        }
        isExplosion = true;
        
        Invoke("Bomb", explosionTime);

    }
    private void Bomb()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider obj in colliders)
        {
            if (obj.gameObject.tag == "soldier")
            {
                audioSource = GetComponent<AudioSource>();
                obj.GetComponent<Rigidbody>().AddExplosionForce(300f, transform.position, explosionRadius, 20f);
                GameObject ExplosionParticle = Instantiate(particle, transform.position, transform.rotation);
                audioSource.PlayOneShot(exSound);

                Destroy(ExplosionParticle, 1f);
                Destroy(obj.gameObject, 0.5f);


            }
            else
            {
                audioSource = GetComponent<AudioSource>();
                GameObject ExplosionParticle = Instantiate(particle, transform.position, transform.rotation);
                audioSource.PlayOneShot(exSound);

                Destroy(ExplosionParticle, 1f);
            }
        }






        Destroy(gameObject, 1.5f);

    }




}
