using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(goToNextScene());
    }

    IEnumerator goToNextScene()
    {
        yield return new WaitForSeconds(40f);
        SceneManager.LoadScene("SampleScene");
    }
}
