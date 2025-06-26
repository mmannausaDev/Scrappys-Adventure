using UnityEngine;

public class CafeDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogCanvas;

    [SerializeField] DialogTrigger dialogTrigger1;

    [SerializeField] ClickableTownObj clickableTownObj;

    private void Awake()
    {
        DialogCanvas.SetActive(true);

        //Logic for which dialog triggers when you enter the cafe will go here
        triggerDialog1();
    }


    public void triggerDialog1()
    {
        dialogTrigger1.TriggerDialog();
    }

    public void leaveCafe()
    {
        if (!DialogCanvas.activeSelf)
        {
            clickableTownObj.backtoTown();
        }
    }
}
