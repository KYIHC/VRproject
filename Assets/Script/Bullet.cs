using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector3 direction;
    public Rigidbody rigidBody;
    public void Shoot(Vector3 direction)
    {
        rigidBody.AddForce(direction);
        Invoke("DestroyBullet", 4f);
    }

    public void DestroyBullet()
    {
        BulletPooling.ReturnObject(this);
    }

    private void Update()
    {
        transform.Translate(direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile") { return; }

        DestroyBullet();
    }
}
