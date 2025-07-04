using UnityEngine;

public class ActionsTracker : MonoBehaviour
{
    [SerializeField] int actionsPerDay = 3;
    int actionsLeft;

    [SerializeField] DaysTracker daysTracker;

    private void Start()
    {
        startOfDay();
    }

    public void startOfDay()
    {
        actionsLeft = actionsPerDay;
    }

    public void useAction()
    {
        actionsLeft--;

        if(actionsLeft <= 0)
        {
            daysTracker.useDay();
        }
    }

    public int getActions()
    {
        return actionsLeft;
    }
}
