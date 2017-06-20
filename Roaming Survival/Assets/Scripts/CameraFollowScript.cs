using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {


    Vector3 playerPosition;
    GameObject player;
    float offset = 0.5f;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y, -offset);
	}
}
