using UnityEngine;

//code borrowed and modified by Zigurous on youtube https://www.youtube.com/watch?v=RYG8UExRkhA
public class BrickStates : MonoBehaviour
{
    public int health {get; private set;}
    public Material[] states;
    public bool unbreakable;
    public MeshRenderer meshRenderer {get; private set;}

    private void Awake()
    {
        this.meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        if (!this.unbreakable)
        {
            this.health = this.states.Length;
            this.meshRenderer.material = this.states[this.health -1];
        }
    }

    private void Hit()
    {
        if (this.unbreakable)
        {
            return;
        }

        this.health--;

        if (this.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.meshRenderer.material = this.states[this.health -1];
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BallMovement" )
        {
            Hit();
        }
    }
}
