using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroid;
    [SerializeField] GameObject[] spawnArray;

    float forceMultiplier = 1.5f;
    float forceIncreaseRate = 0.05f;

    float spawnInterval = 2f;
    float minSpawnInterval = 0.3f;
    float spawnSpeedupRate = 0.025f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    void Update()
    {
        forceMultiplier += forceIncreaseRate * Time.deltaTime;

        if (spawnInterval > minSpawnInterval)
        {
            spawnInterval -= spawnSpeedupRate * Time.deltaTime;
        }
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            spawnStar();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void spawnStar()
    {
        int rand = Random.Range(0, spawnArray.Length);

        GameObject instantiatedObject = Instantiate(asteroid, spawnArray[rand].transform.position, Quaternion.identity);

        float randomScale = Random.Range(0.5f, 1f);
        instantiatedObject.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        instantiatedObject.GetComponent<EnemyBehavior>().setForce(forceMultiplier);
    }
}
