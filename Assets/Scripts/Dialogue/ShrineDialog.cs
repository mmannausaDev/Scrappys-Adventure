using UnityEngine;

public class ShrineDialog : MonoBehaviour
{

    [SerializeField] GameObject DialogCanvas;

    private bool firstConvo = true;

    [SerializeField] DialogTrigger dialogTrigger1;
    [SerializeField] DialogTrigger dialogTrigger2;

    [SerializeField] ClickableTownObj clickableTownObj;

    [SerializeField] ScrapGameHook ScrapGame;
    [SerializeField] TicketHandler ticketHandler;


    private void OnEnable()
    {
        DialogCanvas.SetActive(true);


        if (firstConvo)
        {
            triggerDialog1();
            firstConvo = false;
        }
        else {
            triggerDialog2();

        }



    }


    public void triggerDialog1()
    {
        dialogTrigger1.TriggerDialog();
    }

    public void triggerDialog2()
    {
        dialogTrigger2.TriggerDialog();
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
