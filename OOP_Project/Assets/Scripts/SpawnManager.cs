using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] enemiesPrefab;

    private float spawnRangeX = 20;
    private float spawnRangeZ = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, Random.Range(2f, 5f));
        //StartCoroutine(SpawnEnemy());
    }

    private void SpawnEnemy()
    {
        //yield return new WaitForSeconds(3f);
        for (int i = 0; i < enemiesPrefab.Length; i++)
        {
            Instantiate(enemiesPrefab[i], GenerateSpawnPosition(), enemiesPrefab[i].transform.rotation);
        }
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 randomPos = spawnPoint.position + new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
