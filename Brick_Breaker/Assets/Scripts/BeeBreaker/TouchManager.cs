using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerInput playerInput;
    private InputAction touchPositionAction;
    private InputAction touchPressAction;
    
    private Vector3 initialPlayerPosition;
    private bool isTouching;
    private Vector3 dragDirection = Vector3.right; // Change this to the desired drag direction

    public float moveSpeed = 5.0f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPositionAction = playerInput.actions["TouchPosition"];

        initialPlayerPosition = player.transform.position;

        // Enable Enhanced Touch support
        EnhancedTouchSupport.Enable();
    }

    private void OnEnable()
    {
        touchPositionAction.performed += TouchPressed;
        touchPressAction.started += TouchStarted;
        touchPressAction.canceled += TouchEnded;
    }

    private void OnDisable()
    {
        touchPositionAction.performed -= TouchPressed;
        touchPressAction.started -= TouchStarted;
        touchPressAction.canceled -= TouchEnded;
    }
    
     private void TouchPressed(InputAction.CallbackContext context)
    {
        if (isTouching)
        {
            Vector2 touchDelta = touchPositionAction.ReadValue<Vector2>();

            // Calculate the new player position
            Vector3 newPosition = player.transform.position + new Vector3(touchDelta.x, 0f, 0f);
            newPosition.z = player.transform.position.z;

            // Get the camera's boundaries in world space
            Camera mainCamera = Camera.main;
            float halfPaddleWidth = player.GetComponent<Renderer>().bounds.size.x / 2f;
            float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
            float minX = -cameraHalfWidth + halfPaddleWidth;
            float maxX = cameraHalfWidth - halfPaddleWidth;

            // Clamp the X position within screen bounds
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            // Smoothly move the paddle towards the touch position
            player.transform.position = Vector3.Lerp(player.transform.position, newPosition, moveSpeed * Time.deltaTime);
        }

        //Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
        //position.z = player.transform.position.z;
        //player.transform.position = position;
    }
     
     private void TouchStarted(InputAction.CallbackContext context)
    {
        isTouching = true;
    }

    private void TouchEnded(InputAction.CallbackContext context)
    {
        isTouching = false;
    }
}
