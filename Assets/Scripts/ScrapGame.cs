using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScrapGame : MonoBehaviour
{

    [SerializeField] Rigidbody2D hook;
    [SerializeField] int hookSpeed;

    [SerializeField] private GameObject scrapMetal;
    [SerializeField] private GameObject shipPart;
    [SerializeField] private GameObject pitfall;

    //might not be needed 
    [SerializeField] private Vector2 minGameBoundry;
    [SerializeField] private Vector2 maxGameBoundry;
    [SerializeField] GameObject lastSpawnedScreen; 
    [SerializeField] private Transform spawnLocation;
    private int spawnedScreens = 0;
    

    [SerializeField] private GameObject nextScreen;

    private void Start()
    {

        SpawnScreen(); 
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 screenPoint = Input.mousePosition;
        Vector3 tempHookPos = Camera.main.ScreenToWorldPoint(screenPoint);
        //tempHookPos.x = Mathf.Clamp(tempHookPos.x, minGameBoundry.x, maxGameBoundry.x);
        //tempHookPos.y = Mathf.Clamp(tempHookPos.y, minGameBoundry.y, maxGameBoundry.y);
        //tempHookPos.z = 10.0f;

        //hook.position = Vector3.MoveTowards(hook.position, tempHookPos,  hookSpeed * Time.deltaTime);
        hook.MovePosition(hook.position + new Vector2(tempHookPos.x - hook.position.x, tempHookPos.y - hook.position.y) * hookSpeed * Time.deltaTime);
        //hook.position = tempHookPos; 



    }


    private void FixedUpdate()
    {
        if (lastSpawnedScreen.transform.position.y >= -.4)
        {
            SpawnScreen();
        }
    }

    private void SpawnScreen()
    {
        spawnedScreens++; 
        lastSpawnedScreen = Instantiate(nextScreen, new Vector3( spawnLocation.position.x, spawnLocation.position.y, 9), Quaternion.identity, gameObject.transform);

        int numOfScaapMetal = Random.Range(2, 5);
        for (int i = 0; i < numOfScaapMetal; i++)
        {
            SpawnObject(scrapMetal); 
        }

        if (spawnedScreens > 2)
        {
            int numOfPitfalls = Random.Range(0, 4);
            for (int i = 0; i < numOfPitfalls; i++)
            {
                SpawnObject(pitfall);
            }
        }


        if (spawnedScreens > 10) {
            SpawnObject(shipPart);
        }



    }

    private void SpawnObject(GameObject gameObject)
    {
        Instantiate(gameObject, 
            new Vector2( spawnLocation.position.x + Random.Range(-3, 3), spawnLocation.position.y + Random.Range(-5, 5)), 
            Quaternion.identity);

    }


}
