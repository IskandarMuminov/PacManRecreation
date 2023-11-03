using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private int[,] mapData = new int[,]
    {
        {1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 2},
        {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2, 5},
        {3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3, 2, 5, 5},
        {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
        {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
        {2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3, 2},
        {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
        {4, 5, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4, 2},
        {5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3, 2, 5},
        {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4, 1},
        {2, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4, 0},
        {0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3, 0},
        {0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 2, 2, 2, 2, 1},
        {5, 0, 0, 0, 0, 0, 5, 3, 3, 0, 4, 0, 0, 0, 0}
    };

    public Vector3Int WorldToGridPosition(Vector3 worldPosition)
    {
        Vector3Int gridPosition = new Vector3Int(
            Mathf.FloorToInt(worldPosition.x),
            Mathf.FloorToInt(worldPosition.y),
            0
        );

        return gridPosition;
    }
}
