using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreObject : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int pointVal;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        StartCoroutine(decay());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + pointVal;

        rb.AddForce(Vector2.up * 1);
    }

    public void setVal(int val)
    {
        pointVal = val;
    }

    IEnumerator decay()
    {
        yield return new WaitForSeconds(2f);
    }
}
