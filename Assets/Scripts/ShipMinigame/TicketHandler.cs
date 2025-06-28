using UnityEngine;

public class TicketHandler : MonoBehaviour
{
    public int totalTickets;
    private bool blessed;
    private float blessedValue = 1.25f;
    public void addTickets(int val)
    {
        totalTickets += (int)((float)val * getBlessed());
        blessed = false;
    }

    public int getTickets()
    {
        return totalTickets;
    }

    private float getBlessed()
    {
        if (blessed)
        {
            return blessedValue;
        }
        else
        {
            return 1;
        }

    }

    public void setBlessed()
    {
        blessed = true;
    }
}