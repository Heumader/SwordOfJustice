using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] Tilemap groundMap;
    [SerializeField] Tilemap objectMap;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);




            }
        }
        
        var test = initMap();

        var x = 0;

        
    }

    private void Start()
    {
        UnitManager.Instance.spawnHeroes();
    }

    private Dictionary<Vector2,Tile> initMap()
    {
        Dictionary<Vector2, Tile> map = new Dictionary<Vector2, Tile>();
       var Size = groundMap.size;

        for (int x = 0; x < groundMap.size.x; x++)
        {
            for (int y = 0; y < groundMap.size.y; y++)
            {
                TileBase currentTile = getTileAt(x, y);
                TileData data = null;
                if (dataFromTiles.ContainsKey(currentTile))
                {
                    data = dataFromTiles[currentTile];
                }
                Tile tile = new Tile(null, data);

                map[new Vector2(x, y)] = tile;

                /*
                

                if (data)
                {

                    int xaa = 0;
                }
                */

            }
        }


        return map;
    


    }

    private TileBase getTileAt(int x, int y)
    {
        return groundMap.GetTile(new Vector3Int(groundMap.cellBounds.xMin + x, groundMap.cellBounds.yMin + y, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = groundMap.WorldToCell(mousePosition);

            TileBase clickedTile = groundMap.GetTile(gridPosition);
            bool walkable = dataFromTiles[clickedTile].walkable;
            int i = 0;

           

        }
    }
}
