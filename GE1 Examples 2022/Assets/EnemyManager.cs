using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int maxEnemies;
    private int currentEnemies;

    public int radius;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemy()
    {
        while (currentEnemies < maxEnemies)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-radius, radius), 5, Random.Range(-radius, radius));
            Instantiate(enemy, randomSpawnPosition, Quaternion.identity);
            currentEnemies++;
            yield return new WaitForSeconds(1);
        }
    }
}
