using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeCabinetTrigger : MonoBehaviour
{
    private bool isMouseOver;

    [SerializeField] GameObject dialogCanvas;
    [SerializeField] GameObject mainSceneStuff;
    [SerializeField] Invintory inventory;
    [SerializeField] GameObject objectReceivedScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMouseOver && !dialogCanvas.activeSelf && !objectReceivedScreen.activeSelf)
        {
            if (inventory.hasCoin())
            {
                SceneManager.LoadScene("Ship minigame", LoadSceneMode.Additive);
                mainSceneStuff.SetActive(false);
            }
        }
    }




    void OnMouseOver()
    {
        if (!dialogCanvas.activeSelf)
        {
            // Add your hover effect logic here, like changing color or scale
            Debug.Log("Mouse is over: " + gameObject.name);
            // Example: Change color to red
            GetComponent<Renderer>().material.color = Color.green;
            isMouseOver = true;
        }
    }


    void OnMouseExit()
    {
        //Reset the color
        GetComponent<Renderer>().material.color = Color.white;
        isMouseOver = false;
    }
}
