using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunFire : MonoBehaviour
{
    #region public 변수
    public AnimationClip shootClip;
    public AnimationClip reloadClip;
    public Transform shootPoint;
    public float bulletSpeed = 1000;
    public ParticleSystem muzzleFlash;
    public InputActionReference bButton;
    public float maxBullet = 75;
    public float currentBullet = 75;
    #endregion

    #region private 변수
    private Animator anim;
    private bool isShooting = false;
    Coroutine shooting;
    #endregion
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        if (isShooting == false)
        {
            muzzleFlash.Play();
            anim.SetBool("Shoot", true);
            shooting = StartCoroutine(ShootBullet());
        }
    }
    public void PistolShoot()
    {
        if (isShooting == false)
        {
            muzzleFlash.Play();
            anim.SetTrigger("Shoot");
            ShootPistol();
        }
    }

    public void StopShoot()
    {
        StopCoroutine(shooting);
        anim.SetBool("Shoot", false);
        muzzleFlash.Stop();
    }

    IEnumerator ShootBullet()
    {
        while (currentBullet > 0)
        {
            var bullet = BulletPooling.GetBullet();
            bullet.Invoke("DestroyBullet", 4f);
            if (bullet.TryGetComponent(out Rigidbody rigidBody))
            {
                bullet.transform.position = shootPoint.position;
                bullet.transform.rotation = shootPoint.rotation;
                rigidBody.AddForce(shootPoint.forward * bulletSpeed);
                currentBullet--;
                yield return new WaitForSeconds(shootClip.length);
            }
         
        }
        Debug.Log("Out of Bullet");
        StartCoroutine(RelaodDelay());
    }

    IEnumerator RelaodDelay()
    {
        Debug.Log("Reloading" + reloadClip.length);
        muzzleFlash.Stop();
        isShooting = true;
        anim.SetBool("Shoot", false);
        anim.SetTrigger("Reload");
        yield return new WaitForSeconds(reloadClip.length*2);
        isShooting = false;
        currentBullet = maxBullet;
        Debug.Log("Reload Complete");
        
        yield return null;
    }

    public void Reload(bool isPush)
    {
        if(isPush && currentBullet < 75)
        StartCoroutine(RelaodDelay());
    }
    public void ShootPistol()
    {
        var bullet = BulletPooling.GetBullet();
        bullet.Invoke("DestroyBullet", 4f);
        if (bullet.TryGetComponent(out Rigidbody rigidBody))
        {
            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;
            rigidBody.AddForce(shootPoint.forward * bulletSpeed);
            currentBullet--;
        }
        if (currentBullet == 0)
        {
            StartCoroutine(RelaodDelay());
        }
    }
}
