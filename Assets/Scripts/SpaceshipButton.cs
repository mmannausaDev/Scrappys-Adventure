using UnityEngine;

public class SpaceshipButton : ClickableTownObj
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMouseOver)
        {
            switchingScreens();
        }
    }

    public void switchingScreens()
    {
        cameraTransform.position = newCameraPos;
        correspondingScreen.SetActive(true);
        switchToScreen();
    }
}
