using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GunFire : MonoBehaviour
{
    #region public 변수
    public AnimationClip shootClip;
    public AnimationClip reloadClip;
    public Transform shootPoint;
    public ParticleSystem muzzleFlash;
    public InputActionReference bButton;

    public Image bulletImage;
    public TextMeshProUGUI countUI;
    public float currentBullet;
    public float maxBullet;
    public float bulletSpeed = 1000;
    #endregion

    #region private 변수
    private Animator anim;
    private bool isShooting = false;
    private string count;
    Coroutine shooting;
    Coroutine pistolShooting;
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

    public void StopShoot()
    {
        StopCoroutine(shooting);
        anim.SetBool("Shoot", false);
        muzzleFlash.Stop();
    }

    public void PistolShoot()
    {
        if (isShooting == false)
        {
            muzzleFlash.Play();
            anim.SetTrigger("Shoot");
            pistolShooting = StartCoroutine(ShootPistol());
        }
    }
    IEnumerator ShootPistol()
    {
        var bullet = BulletPooling.GetBullet();
        bullet.Invoke("DestroyBullet", 4f);
        if (currentBullet > 0)
        {
            if (bullet.TryGetComponent(out Rigidbody rigidBody))
            {
                bullet.transform.position = shootPoint.position;
                bullet.transform.rotation = shootPoint.rotation;
                rigidBody.AddForce(shootPoint.forward * bulletSpeed);
                currentBullet--;
                countUI.text = $"{currentBullet}  /  {maxBullet} ".ToString();
                isShooting = true;
                yield return new WaitForSeconds(shootClip.length);
                isShooting = false;
                yield return null;
            }
        }
        else
        {
            StartCoroutine(RelaodDelay());
        }
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
                countUI.text = $"{currentBullet}  /  {maxBullet} ".ToString();
                yield return new WaitForSeconds(shootClip.length);
            }

        }
        StartCoroutine(RelaodDelay());
    }

    IEnumerator RelaodDelay()
    {
        muzzleFlash.Stop();
        isShooting = true;
        anim.SetBool("Shoot", false);
        anim.SetTrigger("Reload");
        yield return new WaitForSeconds(reloadClip.length * 2);
        isShooting = false;
        currentBullet = maxBullet;
        countUI.text = $"{currentBullet}  /  {maxBullet} ".ToString();
        yield return null;
    }

    public void Reload(bool isPush)
    {
        if (isPush && currentBullet < maxBullet)
            StartCoroutine(RelaodDelay());
    }


    public void BulletUI()
    {
        bulletImage.gameObject.SetActive(true);
        countUI.text = $"{currentBullet}  /  {maxBullet} ".ToString();

    }
    public void BulletUIExit()
    {
        bulletImage.gameObject.SetActive(false);
    }
}
