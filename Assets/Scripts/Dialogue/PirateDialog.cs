using UnityEngine;

public class PirateDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogCanvas;

    [SerializeField] DialogTrigger dialogTrigger1;

    [SerializeField] ClickableTownObj clickableTownObj;

    public void leavePrate()
    {


        if (!DialogCanvas.activeSelf)
        {

            clickableTownObj.backtoTown();
        }
    }
}
