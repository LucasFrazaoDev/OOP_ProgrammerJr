using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] enemiesPrefab;

    public float spawnRangeX;
    public float spawnRangeZ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(enemiesPrefab[0], GenerateSpawnPosition(), enemiesPrefab[0].transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 randomPos = spawnPoint.position + new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
