using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefab;
    private bool canSpawn = false;

    public void StartSpawning()
    {
        if(!canSpawn)
        {
            canSpawn = true;
            StartCoroutine(spawner());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while(true)
        {
            yield return wait;

            int rand = Random.Range(0, enemyPrefab.Length);
            GameObject enemyToSpawn = enemyPrefab[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }

    }
}
