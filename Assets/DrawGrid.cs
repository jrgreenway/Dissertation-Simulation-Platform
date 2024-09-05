using UnityEngine;
using UnityEngine.Tilemaps;

public class GridInitializer : MonoBehaviour
    // A useful script which was used to draw a grid on the Tilemap in the Unity Editor, 1000x1000 tiles
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