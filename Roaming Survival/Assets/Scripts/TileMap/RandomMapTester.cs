﻿using UnityEngine;
using System.Collections;

public class RandomMapTester : MonoBehaviour {

    [Header("Map Dimensions")]
    public int mapWidth = 20;
    public int mapHeight = 20;

    [Space]
    [Header("Visualize Map")]
    public GameObject mapContainer;
    public GameObject tilePrefab;
    public Vector2 tileSize = new Vector2(16,16);

    [Space]
    [Header("Map Sprites")]
    public Texture2D islandTexture;

    [Space]
    [Header("Decorate")]
    [Range(0, .9f)]
    public float erodePercent = .5f;
    public int erodeIntertions = 2;
    [Range(0, .9f)]
    public float treePercent = .3f;
    [Range(0, .9f)]
    public float hillPercent = .2f;
    [Range(0, .9f)]
    public float mountainPercent = .1f;
    [Range(0, .9f)]
    public float townPercent = .05f;
    [Range(0, .9f)]
    public float monsterPercent = .1f;
    [Range(0, .9f)]
    public float lakePercent = .05f;


    public Map map;

	// Use this for initialization
	void Start () {
        map = new Map();
	}
	
	public void MakeMap()
    {
        map.NewMap(mapWidth, mapHeight);
        map.CreateIsland(
            erodePercent,
             erodeIntertions ,
             treePercent,
             hillPercent,
             mountainPercent, 
             townPercent,
             monsterPercent,
             lakePercent
             );
        CreateGrid();
    }

    void CreateGrid()
    {
        ClearMapContainer();
        Sprite[] sprites = Resources.LoadAll<Sprite>(islandTexture.name);

        var total = map.tiles.Length;
        var maxColumns = map.colums;
        var column = 0;
        var row = 0;

        for (var i = 0; i < total; i++)
        {
            column = i % maxColumns;

            var newX = column * tileSize.x;
            var newY = -row * tileSize.y;

            var go = Instantiate(tilePrefab);
            go.name = "Tile " + i;
            go.transform.SetParent(mapContainer.transform);
            go.transform.position = new Vector3(newX, newY, 0);
            
            var tile = map.tiles[i];
            var spriteID = tile.autoTileID;
            if (spriteID >= 1)
            {
                var sr = go.GetComponent<SpriteRenderer>();
                sr.sprite = sprites[spriteID];
            }
            if (column == (maxColumns - 1))
            {
                row++;
            }

        }

    }

    void ClearMapContainer()
    {
        var children = mapContainer.transform.GetComponentsInChildren<Transform>();
        for (var i = children.Length - 1; i > 0; i--)
        {
            Destroy(children[i].gameObject);
        }

    }
}
