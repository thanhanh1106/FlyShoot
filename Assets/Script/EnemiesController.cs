using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemiesController : Singleton<EnemiesController>
{
    [SerializeField] List<GameObject> enemyMatrixs;
    [SerializeField] float timeChange;
    List<GameObject> enemies;

    int currentMatrix;
    
    public bool CanTakeDamage { get; private set; }

    private void Start()
    {
        CanTakeDamage = false;
        enemies = new List<GameObject>();
        currentMatrix = 0;
        for(int index = 0; index < transform.childCount; index++)
        {
            enemies.Add(transform.GetChild(index).gameObject);
        }

        Arrage(enemyMatrixs[currentMatrix]);
        StartCoroutine(IECountTimeChange());
    }


    void Arrage(GameObject enemyMatrix)
    {
        for(int index = 0; index < enemyMatrix.transform.childCount; index++)
        {
            Vector3 enemyPos = enemyMatrix.transform.GetChild(index).position;
            Enemy enemy = enemies[index].GetComponent<Enemy>();
            if (enemy)
                enemy.Move(enemyPos);
        }
    }
    IEnumerator IECountTimeChange()
    {
        while(currentMatrix < enemyMatrixs.Count - 1)
        {
            yield return new WaitForSeconds(timeChange);
            currentMatrix++;
            Arrage(enemyMatrixs[currentMatrix]);
        }
        yield return new WaitForSeconds(1f);
        CanTakeDamage = true;
    }
}
