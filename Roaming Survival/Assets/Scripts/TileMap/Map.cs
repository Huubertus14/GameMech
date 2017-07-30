using UnityEngine;
using System.Collections;
using System.Linq;

public enum TileType
{
    Empty = -1,
    Grass = 15,
    Tree = 16,
    Hills = 17,
    Mountains = 18,
    Towns = 19,
    Castle = 20,
    Monster = 21
}

public class Map{

    public Tile[] tiles;
    public int colums, rows;

    public Tile[] coastTiles
    {
        get
        {
            return tiles.Where(t => t.autoTileID < (int)TileType.Grass).ToArray();
        }
    }

    public Tile[] landTiles
    {
        get
        {
            return tiles.Where(t => t.autoTileID == (int)TileType.Grass).ToArray();
        }
    }

    public Tile[] singleLandTiles
    {
        get
        {
            return tiles.Where(t => t.autoTileID == (int)0).ToArray();
        }
    }

    public void NewMap(int width, int height)
    {
        colums = width;
        rows = height;

        tiles = new Tile[colums * rows];

        CreateTiles();
    }

    public void CreateIsland(
        float erodePercent,
        int erodeIterations,
        float treePercent,
        float hillPercent,
        float mountainPercent,
        float townPercent,
        float monsterPercent,
        float lakePercent
    )
    {
        DecorateTiles(landTiles, lakePercent, TileType.Empty);

        for (var i = 0; i < erodeIterations; i++)
        {
            DecorateTiles(coastTiles, erodePercent, TileType.Empty);
        }

        DecorateTiles(landTiles, treePercent, TileType.Tree);
        DecorateTiles(landTiles, hillPercent, TileType.Hills);
        DecorateTiles(landTiles, mountainPercent, TileType.Mountains);
        DecorateTiles(landTiles, townPercent, TileType.Towns);
        DecorateTiles(landTiles, mountainPercent, TileType.Mountains); 
    }

    private void CreateTiles()
    {
        var total = tiles.Length;

        for (int i = 0; i < total; i++)
        {
            var tile = new Tile();
            tile.id = i;
            tiles[i] = tile;
        }

        FindNeighbors();
    }

    private void FindNeighbors()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < colums; c++)
            {
                var tile = tiles[colums * r + c];

                if (r < rows - 1)
                {
                    tile.AddNeighbor(Sides.Bottom, tiles[colums * (r + 1) + c]);
                }

                if(c < colums - 1)
                {
                    tile.AddNeighbor(Sides.Right, tiles[colums * r + c + 1]);
                }

                if(c > 0)
                {
                    tile.AddNeighbor(Sides.Left, tiles[colums * r + c -1]);
                }
                if (r > 0)
                {
                    tile.AddNeighbor(Sides.Top, tiles[colums * (r - 1) + c]); 
                }
            }
        }
    }

    public void DecorateTiles(Tile[] tiles, float percent, TileType type)
    {
        var total = Mathf.FloorToInt(tiles.Length * percent);

        RandomizeTileArray(tiles);

        for (var i = 0; i < total; i++)
        {

            var tile = tiles[i];

            if (type == TileType.Empty)
                tile.ClearNeighbors();

            tile.autoTileID = (int)type;

        }

    }

    public void RandomizeTileArray(Tile[] tiles)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            var tmp = tiles[i];
            var r = Random.Range(i, tiles.Length);
            tiles[i] = tiles[r];
            tiles[r] = tmp;
        }
    }
}
