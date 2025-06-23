using UnityEngine;

public class StarScrollers : MonoBehaviour
{
    [SerializeField] GameObject square;
    [SerializeField] GameObject[] spawnArray;
    int rand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnStar", 0.0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnStar()
    {
        rand = Random.Range(0, spawnArray.Length);

        Instantiate(square, spawnArray[rand].transform.position, Quaternion.identity);
    }
}
