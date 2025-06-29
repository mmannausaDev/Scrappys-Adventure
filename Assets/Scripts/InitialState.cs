using UnityEngine;

public class InitialState : MonoBehaviour
{
    [SerializeField] SpaceshipButton spaceshipbutton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spaceshipbutton.switchingScreens();
    }
}
