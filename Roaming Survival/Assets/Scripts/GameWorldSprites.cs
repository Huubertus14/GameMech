using UnityEngine;
using System.Collections;

public class GameWorldSprites : MonoBehaviour {

    public GameObject grassTile;
    public GameObject[] grassBorderTiles = new GameObject[8];
    public Vector2 worldSize = new Vector2(100,100);

	// Use this for initialization
	void Awake () {
        for (int i = (int)-worldSize.x; i < worldSize.x; i++)
        {
            for (int j = (int)-worldSize.y; j < worldSize.y; j++)
            {
                //Init a world full of grass
                InitializeTile(grassTile, i, j);
            }
        }
	}
	
	private void InitializeTile(GameObject tile, float xPosition, float yPosition)
    {
        Instantiate(tile);
        tile.transform.position = new Vector3(xPosition, yPosition, 0);
    }
}
