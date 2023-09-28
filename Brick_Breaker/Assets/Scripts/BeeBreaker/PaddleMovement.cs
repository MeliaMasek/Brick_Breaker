using UnityEngine;

//code borrowed and modified by Zigurous on youtube https://www.youtube.com/watch?v=RYG8UExRkhA
public class PaddleMovement : MonoBehaviour

{
    public new Rigidbody rigidbody {get; private set;}
    public Vector2 direction {get; private set;}
    public float speed = 30f;
    public float maxBounceAngle = 75f;
    private Vector3 startPos;

    private void Awake()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.direction = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            this.direction = Vector2.right;
        }
        else
        {
            this.direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (this.direction != Vector2.zero)
        {
            this.rigidbody.AddForce(this.direction * this.speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        BallMovement ball = collision.gameObject.GetComponent<BallMovement>();

        if (ball != null)
        {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.collider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);

            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;
        }
    }
    
    public void ResetToZero()
    {
        //startPos = new Vector3(0f, 1.57f, 0f);
        //transform.position = startPos;
        
    }
}
