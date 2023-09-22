using UnityEngine;
using UnityEngine.InputSystem;
public class InputTest : MonoBehaviour
{

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Paddle Jumping" + context.phase);
    }
    
    
}
