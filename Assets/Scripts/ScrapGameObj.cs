using UnityEngine;
using UnityEngine.Windows;

public class ScrapGameObj : MonoBehaviour
{

    [SerializeField] private int currentSpeed = 2;
    private int fastSpeed = 8; 
    private int slowSpeed = 2;
    private ScrapGame scrapGame;


    void Update()
    {

        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            currentSpeed = fastSpeed;
            Debug.Log("going faster"); 

        }
        if (UnityEngine.Input.GetMouseButtonUp(0))
        {
            currentSpeed = slowSpeed;
        }

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("picked up item"); 
        //do something with the item picked up
        //gameObject.SetActive(false);

    }

    public void setScrapGame(ScrapGame scrapGame) { 
        this.scrapGame = scrapGame; 
    }
}
