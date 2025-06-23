using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    GameObject obj;
    GameObject tim;
    AudioSource playSound;

    SpriteRenderer spriterenderer;
    Shooting shooting;
    CountdownController countdownController;

    [SerializeField] int type;

    private void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
        tim = GameObject.FindGameObjectWithTag("GM");
        playSound = GetComponent<AudioSource>();

        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        shooting = obj.GetComponent<Shooting>();
        countdownController = tim.GetComponent<CountdownController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frame"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(sound());
        }
    }

    IEnumerator sound()
    {
        playSound.Play();
        spriterenderer.enabled = false;
        startPowerup();
        countdownController.setTime();
        countdownController.starting();
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    void startPowerup()
    {
        shooting.PowerupEnd();
        if(type == 1) //1 is dual shot
        {
            shooting.dualshot();
        }
        else if(type == 2) //2 is triple shot
        {
            shooting.tripleshot();
        }
        else if(type == 3) //3 is bomb
        {
            shooting.bomb();
        }
    }
}
