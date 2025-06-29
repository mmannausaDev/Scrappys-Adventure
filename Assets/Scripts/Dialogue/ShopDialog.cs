using UnityEngine;

public class ShopDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogCanvas;
    [SerializeField] GameObject objectReceivedScreen;

    [SerializeField] DialogTrigger dialogTrigger1, dialogTrigger2, dialogTriggerEndArcade, dialogTriggerShipPart;

    bool triggeredDialog1 = false;
    bool timeToLeave = false;
    bool gotShipPart = false;

    [SerializeField] ClickableTownObj clickableTownObj;
    [SerializeField] TicketHandler ticketHandler;

    [SerializeField] Invintory inventory;

    private void OnEnable()
    {
        DialogCanvas.SetActive(true);

        //Logic for which dialog triggers when you enter the cafe will go here
        if (!triggeredDialog1)
        {
            triggerDialog1();
        }
        else if (ticketHandler.getTickets() >= 50000 && !gotShipPart)
        {
            gotShipPart = true;
            objectReceivedScreen.SetActive(true);
            inventory.gainNavCube();
            triggerGetShipPartDialog();
        }
        else
        {
            triggerDialog2();
        }
    }

    private void Update()
    {
        if (isActiveAndEnabled && timeToLeave)
        {
            if (!DialogCanvas.activeSelf)
            {
                clickableTownObj.backtoTown();
                timeToLeave = false;
            }
        }
    }


    public void triggerDialog1()
    {
        triggeredDialog1 = true;
        dialogTrigger1.TriggerDialog();
    }

    public void triggerDialog2()
    {
        dialogTrigger2.TriggerDialog();
    }

    public void triggerGetShipPartDialog()
    {
        dialogTriggerShipPart.TriggerDialog();
    }

    public void triggerDialogEndArcade()
    {
        if(ticketHandler.getTickets() >= 50000)
        {
            triggerGetShipPartDialog();
        }
        else
        {
            DialogCanvas.SetActive(true);
            dialogTriggerEndArcade.TriggerDialog();
        }

        timeToLeave = true;
    }

    public void leaveShop()
    {
        if (!DialogCanvas.activeSelf && !objectReceivedScreen.activeSelf)
        {
            clickableTownObj.backtoTown();
        }
    }

    public void closeInvintoryGet()
    {
        objectReceivedScreen.SetActive(false);
    }
}
