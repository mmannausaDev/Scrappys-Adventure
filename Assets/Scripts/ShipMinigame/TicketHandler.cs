using UnityEngine;

public class TicketHandler : MonoBehaviour
{
    public int totalTickets;

    public void addTickets(int val)
    {
        totalTickets += val;
    }

    public int getTickets()
    {
        return totalTickets;
    }
}
