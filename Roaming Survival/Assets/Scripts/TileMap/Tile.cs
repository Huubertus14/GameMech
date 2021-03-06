﻿using UnityEngine;
using System.Collections;
using System;
using System.Text;

public enum Sides
{
    Bottom,
    Right,
    Left,
    Top
}

public class Tile {

    public int id = 0;
    public Tile[] neighbors = new Tile[4];
    public int autoTileID;

    public void AddNeighbor(Sides side, Tile tile)
    {
        neighbors[(int)side] = tile;
        CalculateAutotileID();
    }

    public void RemoveNeighbor(Tile tile)
    {
        var total = neighbors.Length;

        for (int i = 0; i < total; i++)
        {
            if (neighbors[i] != null)
            {
                if(neighbors[i].id == tile.id)
                {
                    neighbors[i] = null;
                }
            }
        }

        CalculateAutotileID();
    }

    public void ClearNeighbors()
    {
        var total = neighbors.Length;
        for (int i = 0; i < total; i++)
        {
            var tile = neighbors[i];
            if(tile != null)
            {
                tile.RemoveNeighbor(this);
                neighbors[i] = null;
            }
        }

        CalculateAutotileID();
    }

    private void CalculateAutotileID()
    {
        var sideValues = new StringBuilder();
        foreach(Tile tile in neighbors)
        {
            sideValues.Append(tile == null ? "0" : "1");
        }

        autoTileID = Convert.ToInt32(sideValues.ToString(), 2);
    }
}
