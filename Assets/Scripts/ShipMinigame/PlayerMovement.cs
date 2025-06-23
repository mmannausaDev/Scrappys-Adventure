using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    bool isTouching = false; // Flag to track if touch/mouse is active
    Vector2 targetPosition; // Store the target position for movement

    public BoxCollider2D boundsBox;

    private float xMin, xMax;
    private float yMin, yMax;

    void Start()
    {
        if (boundsBox != null)
        {
            Bounds bounds = boundsBox.bounds;
            xMin = bounds.min.x;
            xMax = bounds.max.x;
            yMin = bounds.min.y;
            yMax = bounds.max.y;
        }
    }

    void Update()
    {
        // Touch Input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartInput(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                UpdateInput(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                EndInput();
            }
        }

        // Mouse Input
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            StartInput(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0)) // Left mouse button held down
        {
            UpdateInput(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            EndInput();
        }

    }

    void StartInput(Vector2 inputPosition)
    {
        targetPosition = Camera.main.ScreenToWorldPoint(inputPosition);
        isTouching = true;
    }

    void UpdateInput(Vector2 inputPosition)
    {
        if (isTouching)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(inputPosition);
        }
    }

    void EndInput()
    {
        isTouching = false;
    }

    void LateUpdate()
    {
        if (isTouching)
        {
            MoveToTargetPosition();
        }
    }

    void MoveToTargetPosition()
    {
        if (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
            newPosition.y = Mathf.Clamp(newPosition.y, yMin, yMax);

            transform.position = newPosition;
        }
    }

}
