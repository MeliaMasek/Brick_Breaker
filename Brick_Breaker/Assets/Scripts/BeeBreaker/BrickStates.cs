using UnityEngine;

//code borrowed and modified by Zigurous on youtube https://www.youtube.com/watch?v=RYG8UExRkhA
//code borrowed and modified from ChatGPT

public class BrickStates : MonoBehaviour
{
    public int health {get; private set;}
    public Material[] states;
    public bool unbreakable;
    public GameObject prefab;
    public float offset = .5f;
    
    public int rows = 6;
    public int columns = 3;
    public Vector3 objectSpacing = new Vector3(1.2f, 0.5f, 1.2f);
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
            this.meshRenderer.material = this.states[this.health - 1];
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

