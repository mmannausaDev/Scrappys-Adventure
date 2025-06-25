using TMPro;
using UnityEngine;

public class ScrapGameHook : MonoBehaviour
{
    [SerializeField] ScrapGame scrapGame;

    private int scrapMetalCollected = 0;
    private int shipPartsCollected = 0;
    private int pitFallsCollected = 0;
    private int necklaceCollected = 0;

    [SerializeField] int hookSpeed;


    [SerializeField] private Invintory invintory; 

    [SerializeField] private TextMeshProUGUI scrapText;
    [SerializeField] private TextMeshProUGUI shipText;
    [SerializeField] private TextMeshProUGUI pitfallText;

    [SerializeField] private int numOfItemsToEndGame;

    [SerializeField] private BoxCollider2D boundsBox;


    private float xMin, xMax;
    private float yMin, yMax;

    private void FixedUpdate()
    {
        scrapText.text = scrapMetalCollected.ToString();
        Debug.Log(scrapMetalCollected.ToString()); 
        shipText.text = shipPartsCollected.ToString();
        pitfallText.text = pitFallsCollected.ToString();
    }

    private void Start()
    {
        if (boundsBox != null)
        {
            Bounds bounds = boundsBox.bounds;
            xMin = bounds.min.x;
            xMax = bounds.max.x;
            yMin = bounds.min.y;
            yMax = bounds.max.y;
        }
    }

    private void Update()
    {

        Vector2 inputPosition = Input.mousePosition;
        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(inputPosition);

       

        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, hookSpeed * Time.deltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
        newPosition.y = Mathf.Clamp(newPosition.y, yMin, yMax);

        transform.position = newPosition;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("ScrapMetal"))
        {
            //Debug.Log("picked up ScrapMetal");
            scrapMetalCollected++; 
        }
        if (collision.CompareTag("Necklace"))
        {
            //Debug.Log("picked up necklace");
            necklaceCollected++;
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
            //Debug.Log(scrapMetalCollected);
            scrapGame.endGame(scrapMetalCollected, shipPartsCollected, necklaceCollected);

            for (int i = 0; i < scrapMetalCollected; i++) {
                invintory.incrementScrapMetal(); 
            }
             scrapMetalCollected = 0;
             shipPartsCollected = 0;
             pitFallsCollected = 0;
             necklaceCollected = 0;

        }


        collision.gameObject.SetActive(false);
    }
}
