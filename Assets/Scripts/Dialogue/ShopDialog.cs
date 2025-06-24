using UnityEngine;

public class ShopDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogCanvas;

    [SerializeField] DialogTrigger dialogTrigger1;

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
}
