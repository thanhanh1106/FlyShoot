using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : Singleton<BulletPool>
{
    [SerializeField] GameObject bulletPrefab;
    public int poolSize = 15;

    private List<GameObject> bullets = new List<GameObject>();

    protected override void Awake()
    {
        MakeSingleton(false);
        // Khởi tạo pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.transform);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        // tìm viên đạn đang không hoạt động
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                bullet.transform.parent = null;
                return bullet;
            }
        }

        // Nếu hết đạn trong pool thì tạo thêm
        GameObject newBullet = Instantiate(bulletPrefab);
        bullets.Add(newBullet);
        return newBullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.parent = this.transform;
        bullet.transform.position = Vector3.zero;
    }
}
