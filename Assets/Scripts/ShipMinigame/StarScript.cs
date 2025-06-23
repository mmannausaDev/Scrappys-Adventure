using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float force;
    Vector3 endPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyObjectCoroutine());
        endPosition = new Vector3(transform.position.x, -10, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, force * Time.deltaTime);
    }

    IEnumerator DestroyObjectCoroutine()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
