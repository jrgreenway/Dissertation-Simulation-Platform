using UnityEngine;
using UnityEngine.Tilemaps;

public class GridInitializer : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase gridTile;

    void Start()
    {
        DrawGrid();
    }

    void DrawGrid()
    {
        for (int x = 0; x < 1000; x++)
        {
            for (int y = 0; y < 1000; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), gridTile);
            }
        }
    }
}