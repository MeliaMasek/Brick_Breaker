using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputTest : MonoBehaviour
{
    public GameInputData inputs;
    private Vector2 move, movement;
    public FloatData speed;
    private void Awake()
    {
        throw new NotImplementedException();
    }

    private void OnEnable()
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }

    private void FixedUpdate()
    {
        throw new NotImplementedException();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Paddle Jumping" + context.phase);
    }
    
    
}
