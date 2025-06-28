using UnityEngine;

public class DaysTracker : MonoBehaviour
{
    [SerializeField] int numberOfDays = 4;
    int daysLeft;

    [SerializeField] ActionsTracker actionsTracker;

    private void Start()
    {
        daysLeft = numberOfDays;
    }

    public void useDay()
    {
        daysLeft--;

        if(daysLeft <= 0)
        {
            //Code to trigger fail state

            //Maybe also have a check to see if the player has all the parts they need in case they made a mistake near the end of the game or sumthn
        }
    }

    public int getDays()
    {
        return daysLeft;
    }
}
