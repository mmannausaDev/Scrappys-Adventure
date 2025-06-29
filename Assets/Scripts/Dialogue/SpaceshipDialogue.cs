using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipDialogue : MonoBehaviour
{
    [SerializeField] GameObject DialogCanvas;

    [SerializeField] DialogTrigger dialogTrigger1, dialogTrigger2, dialogTrigger3;

    bool triggeredDialog1 = false;
    bool timeToLeave = false;

    [SerializeField] ClickableTownObj clickableTownObj;
    [SerializeField] Invintory inventory;
    bool hasAllParts = false;

    private void OnEnable()
    {
        DialogCanvas.SetActive(true);

        //Logic for which dialog triggers when you enter will go here
        if (inventory.hasAllParts())
        {
            triggerDialog3();
        }
        else if (!triggeredDialog1)
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
        if(hasAllParts && !DialogCanvas.activeSelf)
        {
            SceneManager.LoadScene("Win Scene");
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

    public void triggerDialog3()
    {
        dialogTrigger3.TriggerDialog();
        hasAllParts = true;
    }

    public void leaveShip()
    {
        if (!DialogCanvas.activeSelf)
        {
            clickableTownObj.backtoTown();
        }
    }
}
