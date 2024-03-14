using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField] Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach(var tileData in tileDatas)
        {
            foreach(var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);



                
            }
        }

       
        
        initMap();
    }

    private void initMap()
    {
        var Size = map.size;

        for (int x = 0; x < map.size.x; x++)
        {
            for (int y = 0; y < map.size.y; y++)
            {
                TileBase currentTile = getTileAt(x, y);

                /*
                var data = dataFromTiles[currentTile];
                if (data)
                {

                    int xaa = 0;
                }
                */

            }
        }
    }

    private TileBase getTileAt(int x, int y)
    {
        return map.GetTile(new Vector3Int(map.cellBounds.xMin + x, map.cellBounds.yMin + y, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition);
            bool walkable = dataFromTiles[clickedTile].walkable;
            int i = 0;

           

        }
    }
}
