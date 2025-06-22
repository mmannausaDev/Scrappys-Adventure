using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject firePoint1;
    public GameObject firePoint2;
    public GameObject firePoint3;

    public bool firePoint1bool;
    public bool firePoint2bool;
    public bool firePoint3bool;

    public GameObject myParticleSystem1;
    public GameObject myParticleSystem2;
    public GameObject myParticleSystem3;

    public GameObject bulletPrefab;
    public GameObject bombPrefab;

    public float bulletForce = 20f;

    public float fireDelta = 0.25f;
    public float nextFire = 0.5f;
    private float myTime = 0.0f;

    private AudioSource playSound;
    GameObject holdPrefab;

    void Start()
    {
        holdPrefab = bulletPrefab;

        if (PlayerPrefs.GetFloat("FSpeed") < 0.25f && PlayerPrefs.GetFloat("FSpeed") > 0.0f)
        {
            fireDelta = PlayerPrefs.GetFloat("FSpeed");
        }

        firePoint1bool = true;
        firePoint2bool = false;
        firePoint3bool = false;

        myParticleSystem1.SetActive(true);
        myParticleSystem2.SetActive(false);
        myParticleSystem3.SetActive(false);

        playSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if(Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;

            Shoot();

            nextFire = nextFire - myTime;
            myTime = 0.0f;
        }
    }

    void Shoot()
    {
        GameObject bullet;
        Rigidbody2D rb;

        if (firePoint1bool)
        {
            bullet = Instantiate(bulletPrefab, firePoint1.transform.position, firePoint1.transform.rotation, null);
            rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint1.transform.up * bulletForce, ForceMode2D.Impulse);
        }

        if (firePoint2bool)
        {
            bullet = Instantiate(bulletPrefab, firePoint2.transform.position, firePoint2.transform.rotation, null);
            rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint2.transform.up * bulletForce, ForceMode2D.Impulse);
        }

        if (firePoint3bool)
        {
            bullet = Instantiate(bulletPrefab, firePoint3.transform.position, firePoint3.transform.rotation, null);
            rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint3.transform.up * bulletForce, ForceMode2D.Impulse);
        }

        playSound.Play();
    }


    public void dualshot()
    {
        firePoint1bool = false;
        firePoint2bool = true;
        firePoint3bool = true;

        myParticleSystem1.SetActive(false);
        myParticleSystem2.SetActive(true);
        myParticleSystem3.SetActive(true);
    }

    public void tripleshot()
    {
        firePoint1bool = true;
        firePoint2bool = true;
        firePoint3bool = true;

        myParticleSystem1.SetActive(true);
        myParticleSystem2.SetActive(true);
        myParticleSystem3.SetActive(true);
    }

    public void bomb()
    {
        bulletPrefab = bombPrefab;
        fireDelta = 0.5f;
    }

    public void PowerupEnd()
    {
        firePoint1bool = true;
        firePoint2bool = false;
        firePoint3bool = false;

        myParticleSystem1.SetActive(true);
        myParticleSystem2.SetActive(false);
        myParticleSystem3.SetActive(false);

        bulletPrefab = holdPrefab;

        if (PlayerPrefs.GetFloat("FSpeed") < 0.25f && PlayerPrefs.GetFloat("FSpeed") > 0.0f)
        {
            fireDelta = PlayerPrefs.GetFloat("FSpeed");
        }
    }
}
