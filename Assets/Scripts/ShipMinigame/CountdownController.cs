using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public float countdownTime;
    public Text countdownDisplay;
    public bool isRunning = false;

    public Image fillimage;
    public Image back;

    public GameObject obj;

    private void Start()
    {
        countdownDisplay.gameObject.SetActive(false);
        fillimage.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        obj = GameObject.FindGameObjectWithTag("Player");
        fillimage.fillAmount = 1f;
    }

    public void starting()
    {
        if (isRunning == false)
        {
            StartCoroutine(CountdownToStart());
        }
    }

    public void setTime()
    {
        countdownTime = 10;
    }

    IEnumerator CountdownToStart()
    {
        float value = 0f;
        float duration = countdownTime;
        countdownDisplay.gameObject.SetActive(true);
        fillimage.gameObject.SetActive(true);
        back.gameObject.SetActive(true);

        while (countdownTime > 0)
        {
            isRunning = true;
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
            value = countdownTime / duration;
            fillimage.fillAmount = value;
        }

        obj.GetComponent<Shooting>().PowerupEnd();
        countdownDisplay.gameObject.SetActive(false);
        fillimage.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        isRunning = false;
    }


}
