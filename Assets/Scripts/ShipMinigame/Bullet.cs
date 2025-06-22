using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            GameObject enemy = collision.gameObject;
            
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Top")
        {
            Destroy(gameObject);
        }
    }
}
