using UnityEngine;

public class PirateDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogCanvas;

    bool firstDialog = true;
    bool gotScrap = false;

    [SerializeField] GameObject objectReceivedScreen;
    [SerializeField] Invintory invintory;



    [SerializeField] DialogTrigger dialogTrigger1;
    [SerializeField] DialogTrigger dialogTriggerHasScrap;
    [SerializeField] DialogTrigger dialogTriggerAfterScrap;
    [SerializeField] DialogTrigger dialogTriggerNoScrapYet;

    [SerializeField] ClickableTownObj clickableTownObj;


    private void OnEnable()
    {

        DialogCanvas.SetActive(true);


        if (firstDialog)
        {
            dialogTrigger1.TriggerDialog();
            firstDialog = false;
        }
        else if (invintory.getNumScrapMetal() > 10 && !gotScrap)
        {
            dialogTriggerHasScrap.TriggerDialog();
            gotScrap = true;
            objectReceivedScreen.SetActive(true);
            invintory.gainFuelCrysatl();
        }
        else if (!(invintory.getNumScrapMetal() >= 10))
        {
            dialogTriggerNoScrapYet.TriggerDialog();
        }
        else if (gotScrap)
        {
            dialogTriggerAfterScrap.TriggerDialog();
        }

    }

    public void leavePrate()
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
