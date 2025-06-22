using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScrapGame : MonoBehaviour
{

    [SerializeField] Rigidbody2D hook;
    [SerializeField] int hookSpeed;

    //might not be needed 
    [SerializeField] private Vector2 minGameBoundry;
    [SerializeField] private Vector2 maxGameBoundry;
    [SerializeField] GameObject lastSpawnedScreen; 
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private List<GameObject> gameObjectsToSpawn = new List<GameObject>();
    [SerializeField] private GameObject nextScreen;

    private void Start()
    {
        SpawnObject();
        SpawnObject();
        SpawnObject();
        SpawnObject();

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
        Debug.Log(lastSpawnedScreen.transform.position.y); 
        if(lastSpawnedScreen.transform.position.y >= 0)
        {
            SpawnScreen(); 
        }


    }

    private void SpawnScreen()
    {
        lastSpawnedScreen = Instantiate(nextScreen, new Vector3( spawnLocation.position.x, spawnLocation.position.y, 9), Quaternion.identity, gameObject.transform);
    }

    private void SpawnObject()
    {
        Instantiate(gameObjectsToSpawn[0], 
            new Vector2( spawnLocation.position.x + Random.Range(-3, 3), spawnLocation.position.y + Random.Range(-5, 5)), 
            Quaternion.identity);
    }


}
