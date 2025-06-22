using UnityEngine;

public class ScrapGameHook : MonoBehaviour
{
    private int scrapMetalCollected = 0;
    private int shipPartsCollected = 0;
    private int pitFallsCollected = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("ScrapMetal"))
        {
            Debug.Log("picked up ScrapMetal");
        }
        if (collision.CompareTag("ShipPart"))
        {
            Debug.Log("picked up ShipPart");
        }
        if (collision.CompareTag("PitFall"))
        {
            Debug.Log("picked up PitFall");
        }

        //do something with the item picked up


        collision.gameObject.SetActive(false);
    }
}
