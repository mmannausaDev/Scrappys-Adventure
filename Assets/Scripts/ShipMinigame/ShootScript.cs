using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour
{
    [SerializeField] GameObject bulletprefab;
    bool canShoot = true;
    [SerializeField] float cooldown = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            GameObject bullet = Instantiate(bulletprefab, gameObject.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
            yield return new WaitForSeconds(cooldown);
            canShoot = true;
        }
        
    }
}
