using Unity.VisualScripting;
using UnityEngine;

public class JunkYardTownButton : ClickableTownObj
{
    [SerializeField] private ScrapGame game;
    [SerializeField] private GameObject TutorialUI;

    private bool SkipTutorial = false;

    public override void switchToScreen()
    {
        Debug.Log("I am the override");

        if (SkipTutorial) {
            closeTutorial(); 
        }
        else {
            TutorialUI.SetActive(true);
        }

    }

    public void closeTutorial()
    {
        TutorialUI.SetActive(false);
        game.startGame();
    }

    public void skipTutorial()
    {
        SkipTutorial = true;
        closeTutorial(); 
    }
}
