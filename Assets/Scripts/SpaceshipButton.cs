using UnityEngine;

public class SpaceshipButton : ClickableTownObj
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMouseOver)
        {
            cameraTransform.position = newCameraPos;
            correspondingScreen.SetActive(true);
            switchToScreen();
        }
    }
}
