using Unity.VisualScripting;
using UnityEngine;

public class JunkYardTownButton : ClickableTownObj
{
    [SerializeField] private ScrapGame game;

    public override void switchToScreen()
    {
        Debug.Log("I am the override");
        game.startGame(); 
    }
}
