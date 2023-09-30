using UnityEngine;
using UnityEngine.Events;

public class OnColllisionEnter : MonoBehaviour
{
    public UnityEvent collisionEnterEvent;
    private void OnCollisionEnter(Collision collision)
    {
        collisionEnterEvent.Invoke();
    }
}