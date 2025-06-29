using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    [SerializeField] GameObject skipButton;
    [SerializeField] RawImage img1, img2;

    private void Start()
    {
        SetAlpha(img1, 0f);
        SetAlpha(img2, 0f);

        StartCoroutine(fadeIn());
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

    IEnumerator fadeIn()
    {
        float duration = 5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / duration);
            SetAlpha(img1, alpha);
            SetAlpha(img2, alpha);
            yield return null;
        }

        SetAlpha(img1, 1f);
        SetAlpha(img2, 1f);
    }

    void SetAlpha(RawImage img, float alpha)
    {
        if (img != null)
        {
            Color c = img.color;
            c.a = alpha;
            img.color = c;
        }
    }
}
