using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour
{
    AudioSource shootSound;

    private void Awake()
    {
        shootSound = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        shootSound.Play();
        StartCoroutine(destroyBullet());
    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
