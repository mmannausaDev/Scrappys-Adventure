using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField] AudioSource hitsound;
    public Healthbar healthbar;
    public GameObject obj;
    SpriteRenderer sprite;
    bool canTakeDamage = true;

    EndGameHandler endGameHandler;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Health") > 100)
        {
            maxHealth = PlayerPrefs.GetInt("Health");
        }

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        obj = GameObject.FindGameObjectWithTag("GM");
        endGameHandler = obj.GetComponent<EndGameHandler>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            endGameHandler.endGame();
        }
    }

    public void takeDamage(int dmg)
    {
        currentHealth -= dmg;
        hitsound.Play();

        healthbar.SetHealth(currentHealth);

        StartCoroutine(HitBlink());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (canTakeDamage)
            {
                takeDamage(1);
            }
        }
    }

    IEnumerator HitBlink()
    {
        canTakeDamage = false;
        int count = 0;
        while (count < 3)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.25f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.25f);
            count++;
        }
        canTakeDamage = true;
    }
}