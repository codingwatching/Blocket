using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TESTRULETILES : MonoBehaviour
{
    public RuleTile tile;
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        tilemap.SetTile(new Vector3Int(0,0,0),tile);
        tilemap.SetTile(new Vector3Int(1, 0, 0), tile);
        tilemap.SetTile(new Vector3Int(1, 1, 0), tile);
        tilemap.SetTile(new Vector3Int(0, 1, 0), tile);
        tilemap.SetTile(new Vector3Int(1, -1, 0), tile);
        tilemap.SetTile(new Vector3Int(0, -1, 0), tile);
        tilemap.SetTile(new Vector3Int(1, -2, 0), tile);
        tilemap.SetTile(new Vector3Int(0, -2, 0), tile);

        tilemap.SetTile(new Vector3Int(-3, 0, 0), tile);
        tilemap.RefreshAllTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
