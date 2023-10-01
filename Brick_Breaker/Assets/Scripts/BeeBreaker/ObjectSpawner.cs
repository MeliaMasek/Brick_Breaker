using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//code borrowed and modified from ChatGPT
[Serializable]
public class ColorHealthPair
{
    public Material color;
    public int health;
}
public class ObjectSpawner : MonoBehaviour
{
    public float rowDis;
    public int rowNum;
    public float colDis;
    public int colNum;
    public GameObject prefab;
    public Vector3 spawnLocation;
    public List<ColorHealthPair> colorHealthPairs;
    private List<ColorHealthPair> availablePairs;
    private List<GameObject> spawnedBricks = new List<GameObject>();
    
    public IntData health;
    public Text gamewonText; // Reference to the UI Text component to display the game over message

    void Start()
    {
        SpawnBricks();
    }

    public void ResetBricks()
    {
        // Destroy all previously spawned bricks
        foreach (var brick in spawnedBricks)
        {
            Destroy(brick);
        }

        // Clear the list of spawned bricks
        spawnedBricks.Clear();

        // Spawn new bricks (you can call this from a button click or other events)
        SpawnBricks();
    }
    
    private void SpawnBricks()
    {
        // Initialize the list of available pairs to be a copy of the original colorHealthPairs
        availablePairs = new List<ColorHealthPair>(colorHealthPairs);

        for (int row = 0; row < rowNum; row++)
        {
            for (int col = 0; col < colNum; col++)
            {
                Vector3 position = new Vector3(col * colDis, row * rowDis, 0) + spawnLocation;
                Quaternion rotation = Quaternion.Euler(0, 90, 0);

                GameObject brick = Instantiate(prefab, position, rotation);
                spawnedBricks.Add(brick);
                BrickStates brickStates = brick.GetComponent<BrickStates>();

                if (brickStates != null && availablePairs.Count > 0)
                {
                    // Randomly select a color-health pair from the list of available pairs
                    int randomIndex = UnityEngine.Random.Range(0, availablePairs.Count);
                    ColorHealthPair selectedPair = availablePairs[randomIndex];

                    // Set the material and health based on the selected pair
                    brickStates.states = new Material[] { selectedPair.color };
                    brickStates.health = selectedPair.health;
                    brickStates.meshRenderer.material = selectedPair.color;

                    // Remove the selected pair from the list of available pairs
                    availablePairs.RemoveAt(randomIndex);
                }
            }
        }
    }
    
    public void GameWon()
    {
        // Check if all bricks are gone to trigger game won
        if (spawnedBricks.Count == 0)
        {
            // Enable the game won text
            gamewonText.enabled = true;
        }
        else
        {
            gamewonText.enabled = false;
        }
    }
}