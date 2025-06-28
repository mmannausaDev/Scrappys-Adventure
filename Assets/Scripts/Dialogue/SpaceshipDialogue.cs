using UnityEngine;

public class SpaceshipDialogue : MonoBehaviour
{
    [SerializeField] GameObject DialogCanvas;

    [SerializeField] DialogTrigger dialogTrigger1, dialogTrigger2;

    bool triggeredDialog1 = false;
    bool timeToLeave = false;

    [SerializeField] ClickableTownObj clickableTownObj;

    private void OnEnable()
    {
        DialogCanvas.SetActive(true);

        //Logic for which dialog triggers when you enter will go here
        if (!triggeredDialog1)
        {
            triggerDialog1();
        }
        else
        {
            triggerDialog2();
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

    public void leaveShip()
    {
        if (!DialogCanvas.activeSelf)
        {
            clickableTownObj.backtoTown();
        }
    }
}
