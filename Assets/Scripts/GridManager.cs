using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] TargetSpawnManager targetSpawnManager;

    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject bg;

    [SerializeField] private int width;
    [SerializeField] private int height;

    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = -8; x < (width - 8); x++)
        {
            for (int y = -4; y < (height - 4); y++)
            {
                GameObject gridPoint = spawnPoint;
                gridPoint.name = $"Point{x},{y}";
                GameObject currentPoint = Instantiate(gridPoint, new Vector2(x, y), Quaternion.identity) as GameObject;
                targetSpawnManager.spawnPoints.Add(currentPoint);
                Instantiate(bg, new Vector2(x, y), Quaternion.identity);
            }
        }
    }
}
