using UnityEngine;

public class ColliderSpawner : MonoBehaviour
{
    public float rowDis;
    public int rowNum;
    public float colDis;
    public int colNum;
    public GameObject colliderPrefab;
    public Vector3 spawnLocation;
    private void Start()
    {
        for (int row = 0; row < rowNum; row++)
        {
            for (int column = 0; column < colNum; column++)
            {
                // Calculate the position for the collider based on row and column indices
                Vector3 position = new Vector3(column * colDis, row * rowDis, 0) + spawnLocation;

                Quaternion rotation = Quaternion.Euler(0, 90, 0);

                // Instantiate the collider prefab at the calculated position
                GameObject newCollider = Instantiate(colliderPrefab, position, rotation);

                // You can modify properties of the instantiated collider here if needed
            }
        }
    }
}