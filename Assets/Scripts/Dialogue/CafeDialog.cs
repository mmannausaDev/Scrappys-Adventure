using UnityEngine;

public class CafeDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogCanvas;

    [SerializeField] DialogTrigger dialogTrigger1;
    [SerializeField] DialogTrigger dialogTrigger2HasNecklace;
    [SerializeField] DialogTrigger dialogTriggerNoNecklace;
    [SerializeField] DialogTrigger dialogTriggerAfteNekclace;

    [SerializeField] GameObject objectReceivedScreen;


    [SerializeField] private bool gotNecklace = false;
    [SerializeField] private bool firstDialog = true;

    [SerializeField] ClickableTownObj clickableTownObj;

    [SerializeField] Invintory invintory;

    private void OnEnable()
    {
        DialogCanvas.SetActive(true);
        Debug.Log(invintory.hasNecklace()); 

        if (firstDialog)
        {
            dialogTrigger1.TriggerDialog();
            firstDialog = false;
        }
        else if (invintory.hasNecklace() && !gotNecklace) {
            dialogTrigger2HasNecklace.TriggerDialog();
            gotNecklace = true;
            objectReceivedScreen.SetActive(true);
            invintory.gainSpatula();
            invintory.gainCoin();
        }
        else if (!invintory.hasNecklace())
        {
            dialogTriggerNoNecklace.TriggerDialog();
        }
        else if (invintory.hasNecklace() && gotNecklace)
        {
            dialogTriggerAfteNekclace.TriggerDialog();
        }
    }


    public void leaveCafe()
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
