using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemiePrefabs;
    public Transform[] spawnPoints;

    public float timeBetweenEnemies = 5f;
    private float countdown = 2f;
    private int wavenumber = 1;
   

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnEnemy();
            countdown = timeBetweenEnemies;
        }
        countdown -= Time.deltaTime;
    }

    void SpawnEnemy ()
    {
        for (int i = 0; i < wavenumber; i++)
        {
            SpawnCharacter();
        }
        wavenumber++;
    }
       
    //<3 From Christopher with Love
    void SpawnCharacter()
    {
        int rndEnemy = Random.Range(0, enemiePrefabs.Length);
        int rndSpawn = Random.Range(0, spawnPoints.Length);
        Instantiate(enemiePrefabs[rndEnemy], spawnPoints[rndSpawn].position, Quaternion.identity);
    }
}
