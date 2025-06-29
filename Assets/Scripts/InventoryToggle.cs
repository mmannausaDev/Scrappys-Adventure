using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryToggle : MonoBehaviour
{
    [SerializeField] GameObject notInArcadeCheckerObj;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject inventoryCanvas;
    bool toggle = false;

    [SerializeField] TMP_Text daysText, actionsText, scrapText, ticketText;
    [SerializeField] ActionsTracker actionsTracker;
    [SerializeField] DaysTracker daysTracker;
    [SerializeField] GameObject navCube, spatula, fishOil, dilCrystal, fluxCap;
    [SerializeField] Invintory inventory;
    [SerializeField] TicketHandler ticketHandler;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(notInArcadeCheckerObj.activeSelf && mainCamera.transform.position == new Vector3(0, 0, -15))
            {
                toggle = !toggle;
                inventoryCanvas.SetActive(toggle);
            }

            daysText.text = "Days left: " + daysTracker.getDays();
            actionsText.text = "Actions left: " + actionsTracker.getActions();
            ticketText.text = "" + ticketHandler.getTickets();
            scrapText.text = "" + inventory.getNumScrapMetal();

        }

        if (inventory.hasNavCube())
        {
            navCube.GetComponent<RawImage>().color = Color.white;
        }
        if (inventory.hasSpatula())
        {
            spatula.GetComponent<RawImage>().color = Color.white;
        }
        if (inventory.hasFuel())
        {
            fishOil.GetComponent<RawImage>().color = Color.white;
        }
        if (inventory.hasDilithiumCrysatl())
        {
            dilCrystal.GetComponent<RawImage>().color = Color.white;
        }
        if (inventory.hasFluxCapacitor())
        {
            fluxCap.GetComponent<RawImage>().color = Color.white;
        }



    }
}
