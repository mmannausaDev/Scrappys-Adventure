using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour
{
    [SerializeField] float force;
    Vector3 endPosition;
    [SerializeField] GameObject GM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        StartCoroutine(DestroyObjectCoroutine());
        endPosition = new Vector3(transform.position.x, -10, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, force * Time.deltaTime);

        if (GM == null)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyObjectCoroutine()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
