using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int scoreValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreValue = 0;
        scoreText.text = "" + scoreValue;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + scoreValue;
    }

    public void addScore(int val)
    {
        scoreValue += val;
    }

    public int getScore()
    {
        return scoreValue;
    }
}
