using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenEnemies = 5f;
    private float countdown = 2f;
    private int wavenumber = 1;
   

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnCharacter();
            countdown = timeBetweenEnemies;
        }
        countdown -= Time.deltaTime;
    }
       
    //<3 From Christopher with Love
    void SpawnCharacter()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
