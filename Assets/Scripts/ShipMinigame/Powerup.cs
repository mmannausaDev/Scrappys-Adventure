using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public Transform dual;
    public Transform triple;
    public Transform rocket;
    public Transform bomb;
    public Transform[] spawnpoints;
    public int rand;

    // Update is called once per frame
    void Update()
    {
        if (rand >= 1 && rand <= 50) // 5% chance for dual
        {
            SpawnPowerup(dual);
            Debug.Log("Spawning Dual Powerup");
        }
        else if (rand > 50 && rand <= 75) // 2.5% chance for triple
        {
            SpawnPowerup(triple);
            Debug.Log("Spawning Triple Powerup");
        }
        else if (rand > 75 && rand <= 90) // 0.15% chance for a bomb
        {
            SpawnPowerup(bomb);
            Debug.Log("Spawning Bomb Powerup");
        }

        if (rand > 900) // Rocket spawns regardless
        {
            SpawnPowerup(rocket);
            Debug.Log("Spawning Rocket");
        }
    }

    void SpawnPowerup(Transform powerup)
    {
        Transform _sp = spawnpoints[Random.Range(0, spawnpoints.Length)];
        Instantiate(powerup, _sp.position, _sp.rotation);
        rand = -1; // Reset rand after spawning
    }

    public void RandomNum()
    {
        rand = Random.Range(1, 1001);
        Debug.Log($"Generated Random Number: {rand}");
    }

    public void spawnRocket()
    {
        SpawnPowerup(rocket);
    }
}
