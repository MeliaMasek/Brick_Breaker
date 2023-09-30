using UnityEngine;

//code borrowed and modified by Zigurous on youtube https://www.youtube.com/watch?v=RYG8UExRkhA
//code borrowed and modified from ChatGPT

public class BrickStates : MonoBehaviour
{
    public int health {get; internal set;}
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
            {
                this.health = this.states.Length;
                this.meshRenderer.material = this.states[this.health - 1];
            }
        }
    }

    public void Hit()
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
            this.meshRenderer.material = this.states[this.health - 1];
            Debug.Log("Health: " + this.health);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BeeBall")
        {
            Hit();
        }
    }
}

