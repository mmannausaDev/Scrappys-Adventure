using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject enemySpawner;

    [SerializeField] GameObject endScreenUI;
    [SerializeField] GameObject youDiedText;
    [SerializeField] GameObject scoreScreen;

    [SerializeField] GameObject scoreText1, scoreText2, scoreText3, yourScoreTextObj;
    [SerializeField] TMP_Text yourScoreText;

    [SerializeField] ScoreHandler scoreHandler;
    GameObject GM;
    ExitArcade exitArcade;
    TicketHandler ticketHandler;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("MainGM");
        exitArcade = GM.GetComponent<ExitArcade>();
        ticketHandler = GM.GetComponent<TicketHandler>();
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

        StartCoroutine(BlinkingEndScreen());
    }

    void enterScore()
    {
        int finalScore = scoreHandler.getScore();

        if(PlayerPrefs.GetInt("HighScore") > scoreHandler.getScore())
        {
            finalScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", finalScore);
        }

        yourScoreText.text = "SCR - " + finalScore;

        if (finalScore > 9000)
        {
            yourScoreTextObj.SetActive(true);

            yourScoreTextObj.transform.position = scoreText3.transform.position;
            scoreText3.SetActive(false);

            if (finalScore > 86000)
            {
                yourScoreTextObj.transform.position = scoreText2.transform.position;

                Vector3 scoreText2OgPos = scoreText2.transform.position;
                scoreText2.transform.position = scoreText3.transform.position;

                if (finalScore > 100000)
                {
                    yourScoreTextObj.transform.position = scoreText1.transform.position;
                    scoreText1.transform.position = scoreText2OgPos;
                }
            }
        }

        ticketHandler.addTickets(scoreHandler.getScore());
        StartCoroutine(goBackToStore());
    }

    IEnumerator BlinkingEndScreen()
    {
        int count = 0;
        while (count < 5)
        {
            yield return new WaitForSeconds(.5f);
            youDiedText.SetActive(false);
            yield return new WaitForSeconds(.5f);
            youDiedText.SetActive(true);
            count++;
        }
        youDiedText.SetActive(false);
        scoreScreen.SetActive(true);
        enterScore();
    }

    IEnumerator goBackToStore()
    {
        yield return new WaitForSeconds(5f);
        exitArcade.exitTheArcade();
        SceneManager.UnloadSceneAsync("Ship minigame");
    }
}
