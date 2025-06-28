using UnityEngine;

public class ClickableTownObj : MonoBehaviour
{
    protected bool isMouseOver;
    [SerializeField] protected Transform cameraTransform;
    [SerializeField] protected Vector3 newCameraPos;
    [SerializeField] protected GameObject correspondingScreen;

    ActionsTracker actionsTracker;
    GameObject GM;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("MainGM");
        actionsTracker = GM.GetComponent<ActionsTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMouseOver)
        {
            cameraTransform.position = newCameraPos;
            correspondingScreen.SetActive(true);
            switchToScreen();

            //Every time you go somewhere it will use an action for the day
            actionsTracker.useAction();
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

    public void backtoTown()
    {
        cameraTransform.position = new Vector3(0,0,-15);
        correspondingScreen.SetActive(false);
    }


}
