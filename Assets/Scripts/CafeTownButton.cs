using UnityEngine;

public class CafeTownButton : ClickableTownObj
{
    GameObject cafe;

    public override void switchToScreen()
    {
        Debug.Log("I am the override");
        cafe.SetActive(true);
    }
}
