using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject enemySpawner;

    [SerializeField] GameObject endScreenUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endGame()
    {
        gameUI.SetActive(false);
        enemySpawner.SetActive(false);

        endScreenUI.SetActive(true);
    }
}
