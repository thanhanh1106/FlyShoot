using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 70f;
    [SerializeField] Transform shootPoint;
    [SerializeField] float RateOfFireTime = 0.1f;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(IEShoot());
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 newPosition = transform.position + new Vector3(mouseX, mouseY, 0) * moveSpeed * Time.deltaTime;
        newPosition = Limit(newPosition);

        transform.position = newPosition;
    }

    Vector3 Limit(Vector3 pos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(pos);
        screenPos.x = Mathf.Clamp(screenPos.x, 0, Screen.width);
        screenPos.y = Mathf.Clamp(screenPos.y, 0, Screen.height);
        return Camera.main.ScreenToWorldPoint(screenPos);
    }
    IEnumerator IEShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(RateOfFireTime);
            GameObject bullet = BulletPool.Instance.GetBullet();
            bullet.transform.position = shootPoint.position;
        }
    }
}
