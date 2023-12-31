using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] float timeMove = 1f;
    [SerializeField] float heath = 5f;
    [SerializeField] float scoreBonus = 1f;

    float currentHeath;
    bool isDie => currentHeath <= 0;

    private void Start()
    {
        currentHeath = heath;
    }
    private void Update()
    {
        if (isDie)
        {
            GameManager.Instance.AddScore(scoreBonus);
            gameObject.SetActive(false);
        }
    }
    public void Move(Vector3 pos)
    {
        transform.DOMove(pos,timeMove).SetEase(Ease.Linear);
    }
    public void TakeDamage(float damage)
    {
        currentHeath -= damage;
    }
}
