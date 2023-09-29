using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float rowDis;
    public int rowNum;
    public float colDis;
    public int colNum;
    public GameObject prefab;
    void Start()
    {
        for (int row = 0; row < rowNum; row++)
        {
            for (int col = 0; col < colNum; col++)
            {
                Vector3 position = new Vector3(col * colDis, row * rowDis, 0);
                Quaternion rotation = Quaternion.Euler(0, 90, 0); // 90-degree rotation around the Y-axis
                Instantiate(prefab, position, rotation);   
            }
        }
    }
}