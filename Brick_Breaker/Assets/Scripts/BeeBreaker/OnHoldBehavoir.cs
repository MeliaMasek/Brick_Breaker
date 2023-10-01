using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoldBehavoir : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding;
    public float holdDuration = 2.0f; // Adjust the duration as needed
    public ArrowMovement arrowMovement; // Reference to your ArrowMovement script
    private float holdStartTime;
    
    private void Update()
    {
        if (isHolding)
        {
            // Check if the hold duration has passed
            if (Time.time - holdStartTime >= holdDuration)
            {
                // Trigger the action when the button is held for the specified duration
                arrowMovement.StartMovingLeft(); // Start moving left
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // The button is pressed, start holding
        isHolding = true;
        holdStartTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // The button is released, stop holding and stop moving
        isHolding = false;
        arrowMovement.StopMovingLeft(); // Stop moving left
    }
}