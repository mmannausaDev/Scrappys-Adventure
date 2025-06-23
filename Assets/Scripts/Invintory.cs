using UnityEngine;

public class Invintory : MonoBehaviour
{

    int numScrapMetal = 0;

    bool FluxCapacitor = false;
    bool Fuel = false;
    bool DilithiumCrysatl = false;
    bool NavCube = false;

    public void incrementScrapMetal()
    { 
        numScrapMetal++;
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

     public int getNumScrapMetal()
    {
        return numScrapMetal;
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

     public bool hasAllParts()
    {
        if (hasFluxCapacitor() && hasDilithiumCrysatl() && hasFuel() && hasNavCube())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
