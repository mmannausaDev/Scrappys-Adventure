using UnityEngine;

public class ShopDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogCanvas;

    [SerializeField] DialogTrigger dialogTrigger1, dialogTrigger2, dialogTriggerEndArcade;

    bool triggeredDialog1 = false;
    bool timeToLeave = false;

    [SerializeField] ClickableTownObj clickableTownObj;

    private void OnEnable()
    {
        DialogCanvas.SetActive(true);

        //Logic for which dialog triggers when you enter the cafe will go here
        if (!triggeredDialog1)
        {
            triggerDialog1();
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

    public void triggerDialogEndArcade()
    {
        DialogCanvas.SetActive(true);
        dialogTriggerEndArcade.TriggerDialog();

        timeToLeave = true;
    }
}
