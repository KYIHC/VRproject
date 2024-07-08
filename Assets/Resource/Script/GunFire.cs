using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    #region public 변수
    public AnimationClip shootClip;
    public AnimationClip reloadClip;
    public Transform shootPoint;
    public float bulletSpeed = 1000;
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
        }

    }
    public void BulletCount()
    {
        bulletCount--;
 
        Vector3 direction = shootPoint.forward * bulletSpeed;
        var bullet = BulletPooling.GetBullet();
        bullet.Shoot(direction);   
        if (bulletCount == 0)
        {
            Reload();
        }
    }

    public void StopShoot()
    {
        anim.SetBool("Shoot", false);
    }

    public void Reload()
    {
        if (bulletCount == 0)
        {
            StartCoroutine(RelaodDelay());
        }
    }

    IEnumerator RelaodDelay()
    {
        isShooting = true;
        anim.SetBool("Shoot", false);
        anim.SetTrigger("Reload");
        yield return new WaitForSeconds(reloadClip.length);
        isShooting = false;
        bulletCount = 100;
    }
}
