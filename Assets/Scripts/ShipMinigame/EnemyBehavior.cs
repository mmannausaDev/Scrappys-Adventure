using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
    float force;
    Vector3 endPosition;
    [SerializeField] float deathTimer = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        yield return new WaitForSeconds(deathTimer);
        Destroy(gameObject);
    }

    public void setForce(float val)
    {
        force = val;
    }
}
