using UnityEngine;
using UnityEngine.Events;

public class OnColllisionEnter : MonoBehaviour
{
    public UnityEvent collisionEnterEvent;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with the player!");
        collisionEnterEvent.Invoke();
    }
}