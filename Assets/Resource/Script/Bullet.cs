using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void DestroyBullet()
    {
        BulletPooling.Instance.ReturnObject(this);
       this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile") { return; }
        DestroyBullet();
    }
}
