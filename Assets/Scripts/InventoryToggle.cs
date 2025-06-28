using UnityEngine;
using TMPro;

public class InventoryToggle : MonoBehaviour
{
    [SerializeField] GameObject notInArcadeCheckerObj;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject inventoryCanvas;
    bool toggle = false;

    [SerializeField] TMP_Text daysText, actionsText;
    [SerializeField] ActionsTracker actionsTracker;
    [SerializeField] DaysTracker daysTracker;


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
        }
    }
}
