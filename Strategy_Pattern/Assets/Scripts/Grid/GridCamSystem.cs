using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCamSystem : MonoBehaviour
{
    public float tilesize = 1;
    public int gridWidth;
    public int gridHeight;
   
    void Start()
    {
        Vector3 bottomLeft = Camera.main.ScreenToViewportPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 topRight = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));

        gridWidth = Mathf.CeilToInt((topRight.x - bottomLeft.x) / tilesize);
        gridHeight = Mathf.CeilToInt((topRight.y - bottomLeft.y) / tilesize);

        CreateGrid();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (Camera.main != null )
        {
            Vector3 bottomLeft = Camera.main.ScreenToViewportPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            Vector3 topRight = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));

            gridWidth = Mathf.CeilToInt((topRight.x - bottomLeft.x) / tilesize);
            gridHeight = Mathf.CeilToInt((topRight.y - bottomLeft.y) / tilesize);

            for (int x = 0; x <= gridWidth; x++)
            {
                Vector3 startPosition = new Vector3(bottomLeft.x + x * tilesize, bottomLeft.y, 0);
                Vector3 endPosition = new Vector3(bottomLeft.x + x * tilesize, topRight.y, 0);
                Gizmos.DrawLine(startPosition, endPosition);
            }

            for (int y = 0; y <= gridHeight; y++)
            {
                Vector3 startPosition = new Vector3(bottomLeft.x, bottomLeft.y + y * tilesize, 0);
                Vector3 endPosition = new Vector3(topRight.x, bottomLeft.y + y * tilesize, 0);
                Gizmos.DrawLine(startPosition, endPosition);
            }
        }
    }

    void CreateGrid()
    {
        Debug.Log("Grid Maat: " + gridWidth + gridHeight);
    }
    
}
