using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyTarget;
    public GameObject SpawnArea;
    public GameObject enemyPrefab;
    int level = 0;
    int enemyCount;
    void Awake()
    {
        EventManager.OnEnemyDestroyed += EnemyDestryoed;
        StartCoroutine(WaveManager());
    }
    void EnemyDestryoed()
    {
        if (enemyCount > 0)
            enemyCount--;
        else
            Debug.LogError("[EnemyManager] Cannot decrement enemyCount cause enemyCount is already 0");
    }
    IEnumerator WaveManager()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (enemyCount == 0)
            {
                level++;
                StartCoroutine(StartWave());
            }
        }
    }
    IEnumerator StartWave()
    {
        yield return null;
        for (int i = 0; i < level; i++)
        {
            var enemy = Instantiate(enemyPrefab, RandomPosition(), enemyPrefab.transform.rotation);
            enemy.GetComponent<Enemy>().player = enemyTarget;
        }
        enemyCount = level;
    }
    Vector3 RandomPosition()
    {
        Vector3 position = new Vector3();
        position.x = Random.Range(-SpawnArea.transform.lossyScale.x / 2, SpawnArea.transform.lossyScale.x / 2);
        position.z = Random.Range(-SpawnArea.transform.lossyScale.z / 2, SpawnArea.transform.lossyScale.z / 2);
        position.y = 2;
        return position;
    }
    void OnDisable()
    {
        EventManager.OnEnemyDestroyed -= EnemyDestryoed;
        StopAllCoroutines();
    }
}
