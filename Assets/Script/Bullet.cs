using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = Vector2.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ReturnBullet"))
            BulletPool.Instance.ReturnBullet(this.gameObject);

        Enemy enemy = collision.transform.GetComponent<Enemy>();
        if (enemy && EnemiesController.Instance.CanTakeDamage)
        {
            enemy.TakeDamage(damage);
            BulletPool.Instance.ReturnBullet(this.gameObject);
        }
    }
}
