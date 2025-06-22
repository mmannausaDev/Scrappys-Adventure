using UnityEngine;

public class ClickableTownObj : MonoBehaviour
{
    private bool isMouseOver;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Vector3 newCameraPos;
    [SerializeField] private GameObject correspondingScreen;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMouseOver)
        {
            cameraTransform.position = newCameraPos;
            correspondingScreen.SetActive(true);
            switchToScreen();
        }
    }


    public virtual void switchToScreen() {

    }
        


    void OnMouseOver()
    {
        // Add your hover effect logic here, like changing color or scale
        Debug.Log("Mouse is over: " + gameObject.name);
        // Example: Change color to red
        GetComponent<Renderer>().material.color = Color.red;
        isMouseOver = true; 

    }


    void OnMouseExit()
    {
        //Reset the color
        GetComponent<Renderer>().material.color = Color.white;
        isMouseOver=false;
    }


}
