using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class DaysTracker : MonoBehaviour
{
    [SerializeField] int numberOfDays = 4;
    int daysLeft;
    bool isDayEnded = false;

    [SerializeField] ActionsTracker actionsTracker;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject dayEndScreen;
    [SerializeField] TMP_Text dayendscreenText;
    [SerializeField] AudioSource soundFX;
    [SerializeField] Invintory inventory;

    private void Start()
    {
        daysLeft = numberOfDays;
    }

    private void Update()
    {
        if(mainCamera.transform.position == new Vector3(0,0,-15) && isDayEnded)
        {
            isDayEnded = false;
            if(daysLeft <= 0)
            {
                dayendscreenText.text = "Final Day";
            }
            else
            {
                dayendscreenText.text = daysLeft + " Days Left";

            }

            StartCoroutine(endingDay());
        }
    }

    public void useDay()
    {
        actionsTracker.startOfDay();
        daysLeft--;
        isDayEnded = true;

        if(daysLeft <= 0)
        {
            if (inventory.hasAllParts())
            {
                SceneManager.LoadScene("Win Scene");
            }
            else
            {
                SceneManager.LoadScene("Lose Scene");
            }
        }
    }

    public int getDays()
    {
        return daysLeft;
    }

    IEnumerator endingDay()
    {
        dayEndScreen.SetActive(true);
        //soundFX.Play();
        yield return new WaitForSeconds(3f);
        dayEndScreen.SetActive(false);
    }
}
