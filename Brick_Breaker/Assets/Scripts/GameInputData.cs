using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class GameInputData : ScriptableObject
{
    // Reference to the Input Action Map
    public InputActionMap inputActionMap;

    private void OnEnable()
    {
        // Initialize the Input Action Map
        inputActionMap = new InputActionMap("TouchActionMap");

        // Add the "Touch" action to the Input Action Map
        inputActionMap.AddAction("Touch", binding: "<Touchscreen>/touch");

        // Enable the Input Action Map
        inputActionMap.Enable();
    }
}