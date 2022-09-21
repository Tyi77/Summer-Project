using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform start, end;

    public GameObject enemy;

    public int maxEnemy = 10;

    public float waitSecondToSpawn = 2;

    float sx, sz, ex, ez;

    int enemyCount = 0;

    float timer = 0.0f;

    private void Start()
    {
        // Check if the starting or ending x or z are currect values
        sx = start.position.x <= end.position.x ? start.position.x : end.position.x;
        sz = start.position.z <= end.position.z ? start.position.z : end.position.z;
        ex = start.position.x >= end.position.x ? start.position.x : end.position.x;
        ez = start.position.z >= end.position.z ? start.position.z : end.position.z;
        enemy.GetComponent<Enemy>().destroyEvent += onDestroyEnemy;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitSecondToSpawn)
        {
            StartCoroutine(spawnEnemy());

            timer = 0;
        }
            
    }

    IEnumerator spawnEnemy()
    {
        if (enemyCount < maxEnemy)
        {
            enemyCount++;
            Vector3 spawnLocation = new Vector3(Random.Range(sx, ex), transform.position.y, Random.Range(sz, ez));
            GameObject ienemy = Instantiate(enemy, spawnLocation, enemy.transform.rotation);
            ienemy.GetComponent<Enemy>().destroyEvent += onDestroyEnemy;
            ienemy.transform.parent = this.transform;
        }

        yield return null;
    }

    private void onDestroyEnemy()
    {
        enemyCount--;
    }
}
