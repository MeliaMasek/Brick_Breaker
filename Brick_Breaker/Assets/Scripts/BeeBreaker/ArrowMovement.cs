using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private bool isMovingLeft;
    private bool isMovingRight;

    private void Update()
    {
        if (isMovingLeft)
        {
            MoveLeft();
        }
        else if (isMovingRight)
        {
            MoveRight();
        }
    }

    public void StartMovingLeft()
    {
        isMovingLeft = true;
    }

    public void StopMovingLeft()
    {
        isMovingLeft = false;
    }

    public void StartMovingRight()
    {
        isMovingRight = true;
    }

    public void StopMovingRight()
    {
        isMovingRight = false;
    }

    private void MoveLeft()
    {
        // Calculate movement to the left
        Vector3 movement = Vector3.left * (moveSpeed * Time.deltaTime);

        // Move the object
        transform.Translate(movement);
    }

    private void MoveRight()
    {
        // Calculate movement to the right
        Vector3 movement = Vector3.right * (moveSpeed * Time.deltaTime);

        // Move the object
        transform.Translate(movement);
    }
}
