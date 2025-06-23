using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
    float force;
    Vector3 endPosition;
    [SerializeField] float deathTimer = 5f;
    int health;
    int pointVal;
    ScoreHandler scoreHandler;

    [SerializeField] GameObject scoreobject;

    void Start()
    {
        scoreHandler = GameObject.FindGameObjectWithTag("GM").GetComponent<ScoreHandler>();

        StartCoroutine(DestroyObjectCoroutine());
        endPosition = new Vector3(transform.position.x, -10, transform.position.z);

        float size = transform.localScale.x;
        if (size < 0.65f)
        {
            health = 1;
            pointVal = 1000;
        }
        else if (size < 0.85f)
        {
            health = 2;
            pointVal = 2000;
        }
        else
        {
            health = 3;
            pointVal = 3000;
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, force * Time.deltaTime);
    }

    IEnumerator DestroyObjectCoroutine()
    {
        yield return new WaitForSeconds(deathTimer);
        Destroy(gameObject);
    }

    public void setForce(float val)
    {
        force = val;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);

            health -= 1;
            if (health <= 0)
            {
                scoreHandler.addScore(pointVal);
                GameObject instantiatedObject = Instantiate(scoreobject, gameObject.transform.position, Quaternion.identity);
                instantiatedObject.GetComponent<ScoreObject>().setVal(pointVal);
                Destroy(gameObject);
            }
        }
    }
}
