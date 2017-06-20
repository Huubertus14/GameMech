using UnityEngine;
using System.Collections;

public class GameWorldSprites : MonoBehaviour {

    public GameObject grass;
    public int worldSize = 160;

	// Use this for initialization
	void Awake () {

	//Make world in positiove direction
    /*
    for (int i = 0; i < worldSize; i++)
        {
            for (int j = 0; j < worldSize; j++)
            {
                    Instantiate(grass);
                    grass.transform.position = new Vector3(i, j, 0);
                    Instantiate(grass);
                    grass.transform.position = new Vector3(j, i, 0);
            }
        }*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
