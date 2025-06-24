using UnityEngine;

public class Invintory : MonoBehaviour
{

    int numScrapMetal = 0;
    int numTickets = 0;

    bool FluxCapacitor = false;
    bool Fuel = false;
    bool DilithiumCrysatl = false;
    bool NavCube = false;
    bool Spatula = false;
    bool Necklace = false;


    public void incrementScrapMetal()
    { 
        numScrapMetal++;
    }

    public void incrementTickets()
    {
        numTickets++;
    }

    public void gainFluxCapacitor()
    {
        FluxCapacitor = true;
    }

    public void gainDilithiumCrysatl()
    {
        DilithiumCrysatl = true;
    }

    public void gainFuelCrysatl()
    {
        Fuel = true;
    }

     public void gainNavCube()
    {
        NavCube = true;
    }

    public void gainSpatula()
    {
        Spatula = true;
    }

    public void gainNecklace()
    {
        Necklace = true;
    }

    public int getNumScrapMetal()
    {
        return numScrapMetal;
    }

    public int getNumTickets()
    {
        return numTickets;
    }

    public bool hasFluxCapacitor()
    {
        return FluxCapacitor; 
    }

     public bool hasDilithiumCrysatl()
    {
        return DilithiumCrysatl;
    }

     public bool hasFuel()
    {
        return Fuel;
    }

     public bool hasNavCube()
    {
        return NavCube;
    }
    public bool hasSpatula()
    {
        return Spatula;
    }

    public bool hasNecklace()
    {
        return Necklace;
    }

    public bool hasAllParts()
    {
        if (hasFluxCapacitor() && hasDilithiumCrysatl() && hasFuel() && hasNavCube() && hasSpatula())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
