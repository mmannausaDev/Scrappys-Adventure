using UnityEngine;

public class ShrineDialog : MonoBehaviour
{

    [SerializeField] GameObject DialogCanvas;

    [SerializeField] DialogTrigger dialogTrigger1;

    [SerializeField] ClickableTownObj clickableTownObj;

    [SerializeField] ScrapGameHook ScrapGame;
    [SerializeField] TicketHandler ticketHandler;


    private void OnEnable()
    {
        DialogCanvas.SetActive(true);

        //Logic for which dialog triggers when you enter the cafe will go here
        triggerDialog1();
 
    }


    public void triggerDialog1()
    {
        dialogTrigger1.TriggerDialog();
    }


    public void leaveShrine()
    {

        
        if (!DialogCanvas.activeSelf)
        {
            ticketHandler.setBlessed(); 
            ScrapGame.setBlessed();
            clickableTownObj.backtoTown();
        }
    }
}
