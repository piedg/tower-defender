using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoSingleton<GridManager>
{
    public int width = 9, height = 5;

    [SerializeField] private GameObject tile;
    [SerializeField] private float cameraOffsetX = 0.5f, cameraOffsetY = 0.5f;

    float[] tilesPositionsY;
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

                GameObject spawnedTile = Instantiate(tile, new Vector3(x, y), Quaternion.identity);

                spawnedTile.transform.parent = transform;
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.GetComponent<Tile>().Init(isOffset);

            }
        }
    }

    void CenterCamera()
    {
        Camera.main.transform.position = new Vector3((float)width / 2 - cameraOffsetX, (float)height / 2 - cameraOffsetY, -10);
    }
}
