using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width = 9, height = 5;
    [SerializeField] private Tile tile;
    [SerializeField] private float cameraOffsetX = 0.5f, cameraOffsetY = 0.5f; 
    
    private void Start()
    {
        GenerateGrid();
        CenterCamera();
    }

    void GenerateGrid()
    {
        for (float x = 0; x < width * 1.5f; x += 1.5f)
        {
            for (float y = 0; y < height * 1.5f; y += 1.5f)
            {
                bool isOffset = ((x / 1.5f) + (y / 1.5f)) % 2 == 1;

                Tile spawnedTile = Instantiate(tile, new Vector3(x, y), Quaternion.identity);

                spawnedTile.transform.parent = transform;
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.Init(isOffset);
            }
        }
    }

    void CenterCamera()
    {
        Camera.main.transform.position = new Vector3((float)width / 2 - cameraOffsetX, (float)height / 2 - cameraOffsetY, -10);
    }
}
