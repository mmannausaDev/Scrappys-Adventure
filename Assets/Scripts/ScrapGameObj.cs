using UnityEngine;
using UnityEngine.Windows;

public class ScrapGameObj : MonoBehaviour
{

    [SerializeField] private int currentSpeed = 2;
    private int fastSpeed = 8; 
    private int slowSpeed = 2;

    [SerializeField] private int yPostoDelete;

    void Update()
    {

        if (UnityEngine.Input.GetMouseButton(0))
        {
            currentSpeed = fastSpeed;
            //Debug.Log("going faster"); 

        }
        if (UnityEngine.Input.GetMouseButtonUp(0))
        {
            currentSpeed = slowSpeed;
        }

        if(transform.position.y >= yPostoDelete)
        {
            Destroy(gameObject);
            //Debug.Log(transform.position.y); 
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("picked up item"); 
        //do something with the item picked up
        //gameObject.SetActive(false);

    }

}
