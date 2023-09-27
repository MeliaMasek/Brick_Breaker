using UnityEngine;
using Random = UnityEngine.Random;

//code borrowed and modified by Zigurous on youtube https://www.youtube.com/watch?v=RYG8UExRkhA
//code borrowed and modified from ChatGPT
public class BallMovement : MonoBehaviour
{
    public new Rigidbody rigidbody {get; private set;}
    public float speed = 5f;
    private Vector3 startPos;
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Start()
    {
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void Update()
    {
        // Limit the velocity to maintain a constant speed.
        Vector3 currentVelocity = rigidbody.velocity;
        float currentSpeed = currentVelocity.magnitude;

        if (currentSpeed != 0f && currentSpeed != speed)
        {
            Vector3 newVelocity = currentVelocity.normalized * speed;
            rigidbody.velocity = newVelocity;
        }
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        
        this.rigidbody.AddForce(force.normalized * this.speed);
    }
    
    public void ResetToZero()
    {
        startPos = new Vector3(0f, 2.5f, 0f);
        transform.position = startPos;
    }
}
