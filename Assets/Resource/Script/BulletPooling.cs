using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolCount = 70;

    public Queue<Bullet> bulletPool = new Queue<Bullet>();
    public static BulletPooling Instance;

    private void Awake()
    {
        Instance = this;
        Initialize(poolCount);
    }

    private void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            bulletPool.Enqueue(CreateNewBullet());
        }
    }

    private Bullet CreateNewBullet()
    {
        var bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
        bullet.transform.SetParent(null);
        bullet.gameObject.SetActive(false);
        return bullet;
    }

    public static Bullet GetBullet()
    {
        if (Instance.bulletPool.Count > 0)
        {
            var bullet = Instance.bulletPool.Dequeue();
            bullet.transform.SetParent(null);
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            var bullet = Instance.CreateNewBullet();
            bullet.gameObject.SetActive(true);
            bullet.transform.SetParent(null);
            return bullet;
        }
    }

    public static void ReturnObject(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(Instance.transform);
        Instance.bulletPool.Enqueue(bullet);
    }
}
