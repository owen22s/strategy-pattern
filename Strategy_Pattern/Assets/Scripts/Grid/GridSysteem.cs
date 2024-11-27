using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSysteem : MonoBehaviour
{
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float tileSize = 1f;

    public GameObject enemyPrefab;
   
    void Start()
    {
        CreateGrid();
        SpawnEnemyPosition(enemyPrefab, 3, 5);
        
       
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridWidth; x++) 
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 tileposition = new Vector3(x * tileSize, y * tileSize, 0);
                Debug.Log("Grid Tile at: " + tileposition);
            }
        }
    }

    public void SpawnEnemyPosition(GameObject objectspawn, int x,  int y)
    {
        Vector3 spawnPosition = new Vector3(x * tileSize, y * tileSize, 0);
        Instantiate(objectspawn, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int x = 0; x <= gridWidth; x++)
        {
            Vector3 startPosition = new Vector3(x * tileSize, 0, 0);
            Vector3 endPosition = new Vector3(x * tileSize, gridHeight * tileSize, 0);
            Gizmos.DrawLine(startPosition, endPosition);
        }

        for (int y = 0; y <= gridHeight; y++)
        {
            Vector3 startPosition = new Vector3(0, y * tileSize, 0);
            Vector3 endPosition = new Vector3(gridWidth * tileSize, y * tileSize, 0);


            Gizmos.DrawLine(startPosition, endPosition);
        }

    }
}
