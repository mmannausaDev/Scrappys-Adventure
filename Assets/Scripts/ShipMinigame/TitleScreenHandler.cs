using UnityEngine;
using TMPro;
using System.Collections;

public class TitleScreenHandler : MonoBehaviour
{
    [SerializeField] GameObject cointTextObject;
    [SerializeField] GameObject ship;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject enemySpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(blinkText());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && titleUI.activeSelf)
        {
            startGame();
        }
    }

    void startGame()
    {
        gameUI.SetActive(true);
        titleUI.SetActive(false);
        ship.SetActive(true);
        enemySpawner.SetActive(true);
    }

    IEnumerator blinkText()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            cointTextObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
            cointTextObject.SetActive(true);
        }
    }
}
