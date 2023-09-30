using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public GameInputData inputs; // Assign your GameInputData asset in the Inspector
    private Vector2 move, movement, moveInput;
    public float moveSpeed = 5.0f;

    private void Awake()
    {
        // Ensure that inputs is properly assigned in the Inspector
        if (inputs == null)
        {
            Debug.LogError("Input Data not assigned!");
            return;
        }

        // Find the "Touch" action within the "TouchActionMap" action map
        InputAction touchAction = inputs.inputActionMap["Touch"];

        // Register a callback for the found action
        touchAction.performed += context => TouchInput(context);

        // Enable the Input Action Map (you may want to do this conditionally)
        inputs.inputActionMap.Enable();
    }

    private void Update()
    {
        // Move the paddle based on input
        Vector3 newPosition = transform.position + new Vector3(moveInput.x, 0, 0) * moveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
    
    // Define the callback function to handle touch input
    private void TouchInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            // Handle touch input here
            Debug.Log("Touch input detected!");
        }
    }
    
    // Callback function for the "MovePaddle" input action
    public void OnMovePaddle(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}