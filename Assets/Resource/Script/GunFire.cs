using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    #region public 변수
    public AnimationClip shootClip;
    public AnimationClip reloadClip;
    public Transform shootPoint;
    public float bulletSpeed = 1000;
    public ParticleSystem muzzleFlash;
    #endregion

    #region private 변수
    private Animator anim;
    private bool isShooting = false;
    private float bulletCount = 100;
    #endregion
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        if (isShooting == false)
        {
            anim.SetBool("Shoot", true);
            muzzleFlash.Play();
            StartCoroutine(ShootBullet());
        }
    }

    public void StopShoot()
    {
        StopAllCoroutines();
        anim.SetBool("Shoot", false);
        muzzleFlash.Stop();
    }

    IEnumerator ShootBullet()
    {
        while (bulletCount > 0 && isShooting == false)
        {
            bulletCount--;
            var bullet = BulletPooling.GetBullet();
            bullet.Invoke("DestroyBullet", 4f);
            if (bullet.TryGetComponent(out Rigidbody rigidBody))
            {
                bullet.transform.position = shootPoint.position;
                bullet.transform.rotation = shootPoint.rotation;
                rigidBody.AddForce(shootPoint.forward * bulletSpeed);
                yield return new WaitForSeconds(shootClip.length);
            }
        }
        if (bulletCount == 0)
        {
            StartCoroutine(RelaodDelay());
            yield return new WaitForSeconds(reloadClip.length);
            isShooting = false;
            bulletCount = 100;
            yield break;
        }
    }
    IEnumerator RelaodDelay()
    {
        muzzleFlash.Stop();
        isShooting = true;
        anim.SetBool("Shoot", false);
        anim.SetTrigger("Reload");
        yield return new WaitForSeconds(reloadClip.length);

    }
}
