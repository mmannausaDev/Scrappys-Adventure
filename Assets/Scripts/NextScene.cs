using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] GameObject skipButton;

    private void Start()
    {
        StartCoroutine(goToNextScene());
        StartCoroutine(skipbuttonappear());
    }

    IEnumerator goToNextScene()
    {
        yield return new WaitForSeconds(40f);
        SceneManager.LoadScene("SampleScene");
    }

    public void skip()
    {
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator skipbuttonappear()
    {
        yield return new WaitForSeconds(3f);
        skipButton.SetActive(true);
    }
}
