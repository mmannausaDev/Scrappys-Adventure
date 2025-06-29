using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

public class ScrapGame : MonoBehaviour
{

    [SerializeField] Rigidbody2D hook;
    //[SerializeField] int hookSpeed;

    [SerializeField] private GameObject scrapMetal;
    [SerializeField] private GameObject shipPart;
    [SerializeField] private GameObject pitfall;
    [SerializeField] private GameObject necklace;

    //might not be needed 
    //[SerializeField] private Vector2 minGameBoundry;
    //[SerializeField] private Vector2 maxGameBoundry;
    [SerializeField] GameObject lastSpawnedScreen; 
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private Transform initialSpawnLocation;
    private int spawnedScreens = 0;
    private bool spawnedShipPart = false;
    private bool spawnedNecklace = false;


    [SerializeField] private TextMeshProUGUI scrapText;
    [SerializeField] private GameObject shipText;
    [SerializeField] private GameObject necklaceText;
    [SerializeField] private GameObject endGameScreen;

    private List<GameObject> spawnedScreensList = new List<GameObject>();
    private List<GameObject> spawnedItemList = new List<GameObject>();



    [SerializeField] Camera cam;
    

    [SerializeField] private GameObject nextScreen;

    private void Start()
    {

        //startGame(); 
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 screenPoint = Input.mousePosition;
        //Vector3 tempHookPos = Camera.main.ScreenToWorldPoint(screenPoint);

        //tempHookPos.z = 10.0f;

        //tempHookPos = Vector3.MoveTowards(hook.position, tempHookPos,  hookSpeed * Time.deltaTime);

        //tempHookPos.x = Mathf.Clamp(tempHookPos.x, minGameBoundry.x, maxGameBoundry.x);
        //tempHookPos.y = Mathf.Clamp(tempHookPos.y, minGameBoundry.y, maxGameBoundry.y);

        //hook.position = tempHookPos; 
        //hook.MovePosition(hook.position + new Vector2(tempHookPos.x - hook.position.x, tempHookPos.y - hook.position.y) * hookSpeed * Time.deltaTime);
        //hook.position = tempHookPos; 

    }

    public void startGame()
    {
        Debug.Log("game start");
        spawnedScreens = 0; 
        SpawnScreen(initialSpawnLocation.position);
        SpawnScreen(spawnLocation.position);

    }

    public void endGame(int scrapMetalCollected, int shipPartsCollected, int necklaceCollected)
    {

        endGameScreen.SetActive(true);
        Debug.Log("Scrap metal int: " + scrapMetalCollected);
        Debug.Log("Scrap metal string: " + scrapMetalCollected.ToString());
        scrapText.text = scrapMetalCollected.ToString();
        
        if (shipPartsCollected > 0)
        {

            shipText.SetActive(true);
        }
        if (necklaceCollected > 0)
        {

            necklaceText.SetActive(true);
        }


        
        spawnedShipPart = false;
        spawnedNecklace = false;
        for (int i = 0; i < spawnedScreensList.Count; i++)
        {
            Destroy(spawnedScreensList[i]); 
        }
        for (int i = 0; i < spawnedItemList.Count; i++)
        {
            Destroy(spawnedItemList[i]);
        }



        //gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (lastSpawnedScreen != null && lastSpawnedScreen.transform.position.y >= -.4)
        {
            SpawnScreen(spawnLocation.position);
        }
    }

    private void SpawnScreen(Vector2 spawnlocation)
    {
        spawnedScreens++; 
        lastSpawnedScreen = Instantiate(nextScreen, new Vector3(spawnlocation.x, spawnlocation.y, 9), Quaternion.identity, gameObject.transform);
        spawnedScreensList.Add(lastSpawnedScreen);
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

        if (spawnedScreens > 5 && !spawnedNecklace)
        {
            SpawnObject(necklace);
            spawnedNecklace = true;
        }

        if (spawnedScreens > 10 && !spawnedShipPart) {
            SpawnObject(shipPart);
            spawnedShipPart = true; 
        }
    }

    private void SpawnObject(GameObject gameObject)
    {
        spawnedItemList.Add(Instantiate(gameObject, 
            new Vector2( spawnLocation.position.x + Random.Range(-3, 3), spawnLocation.position.y + Random.Range(-5, 5)), 
            Quaternion.identity));

    }

    public void closeEndGameRecap()
    {
        endGameScreen.SetActive(false);
        gameObject.SetActive(false);
        cam.transform.position = new Vector3(0, 0, -15);
    }


}
