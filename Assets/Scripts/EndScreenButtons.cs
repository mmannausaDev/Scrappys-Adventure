using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButtons : MonoBehaviour
{

    public void restartGame()
    {
        SceneManager.LoadScene(0); 
    }
}
