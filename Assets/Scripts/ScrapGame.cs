using UnityEngine;

public class ScrapGame : MonoBehaviour
{

    [SerializeField] Transform hook;
    [SerializeField] private Vector2 minGameBoundry;
    [SerializeField] private Vector2 maxGameBoundry;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 screenPoint = Input.mousePosition;
        Debug.Log(screenPoint); 
        Vector3 tempHookPos = Camera.main.ScreenToWorldPoint(screenPoint);
        Debug.Log(tempHookPos);
        tempHookPos.x = Mathf.Clamp(tempHookPos.x, minGameBoundry.x, maxGameBoundry.x);
        tempHookPos.y = Mathf.Clamp(tempHookPos.y, minGameBoundry.y, maxGameBoundry.y);
        tempHookPos.z = 10.0f;
        Debug.Log(tempHookPos);
        hook.position = tempHookPos; 


    }
}
