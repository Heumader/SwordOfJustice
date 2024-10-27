using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{

    public Tile(BaseUnit unit, TileData tileData)
    {
        this.unit = unit;
        this.tileData = tileData;
    }

    public BaseUnit unit;
    public TileData tileData;

}
