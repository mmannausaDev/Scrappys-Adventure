using UnityEngine;

public class ScrapGameHook : MonoBehaviour
{
    [SerializeField] ScrapGame scrapGame;

    private int scrapMetalCollected = 0;
    private int shipPartsCollected = 0;
    private int pitFallsCollected = 0;
    [SerializeField] private int numOfItemsToEndGame; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("ScrapMetal"))
        {
            //Debug.Log("picked up ScrapMetal");
            scrapMetalCollected++; 
        }
        if (collision.CompareTag("ShipPart"))
        {
            //Debug.Log("picked up ShipPart");
            shipPartsCollected++;
        }
        if (collision.CompareTag("PitFall"))
        {
            //Debug.Log("picked up PitFall");
            pitFallsCollected++;
        }

        //do something with the item picked up
        if(scrapMetalCollected + shipPartsCollected + pitFallsCollected >= numOfItemsToEndGame)
        {
             scrapMetalCollected = 0;
             shipPartsCollected = 0;
             pitFallsCollected = 0;

            scrapGame.endGame();
        }


        collision.gameObject.SetActive(false);
    }
}
