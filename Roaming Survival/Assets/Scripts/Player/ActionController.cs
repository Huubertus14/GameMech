using UnityEngine;
using System.Collections;

public class ActionController : MonoBehaviour {

    readonly private Vector3 STARTPOINT = new Vector3(0,0,0);
    readonly private Vector3 UPPOINT = new Vector3(0, 0.7f, 0);
    readonly private Vector3 DOWNPOINT = new Vector3(0, -0.7f, 0);
    readonly private Vector3 RIGHTPOINT = new Vector3(0.7f, 0, 0);
    readonly private Vector3 LEFTPOINT = new Vector3(-0.7f, 0, 0);


    private PlayerMovement playerMove;

    private GameObject actionBox;
    private GameObject player;

    public float actionCounter = 0f;
    public float actionTimer = 1.1f;

    private SpriteRenderer spr;
    public Sprite actionDown;
    public Sprite actionUp;
    public Sprite actionLeft;
    public Sprite actionRight;

    // Use this for initialization
    void Awake () {
        actionBox = GameObject.FindGameObjectWithTag("ActionBox");
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = gameObject.GetComponent<PlayerMovement>();
        spr = gameObject.GetComponentInChildren<SpriteRenderer>();
	}
	

    // Update is called once per frame
    void FixedUpdate () {
        ActionUse();
	}

    private void ActionUse()
    {
        if(actionCounter > -1)
        {
            actionCounter -= 1 * Time.deltaTime;
        }

        if (actionCounter < 0)
        {
            actionBox.transform.position = player.transform.position;
            CheckRestAnimantion();

            if (Input.GetKeyDown(KeyCode.Space) && !playerMove.checkIfWalking()){
             actionCounter = actionTimer;

            if (playerMove.getState() == 0)
            {
                //Action up down
                actionBox.transform.position = player.transform.position + DOWNPOINT;
                    SetAnimation(actionDown);
                }
            if (playerMove.getState() == 1)
            {
                //Action Up
                actionBox.transform.position = player.transform.position + UPPOINT;
                    SetAnimation(actionUp);
                }
            if (playerMove.getState() == 2)
            {
                //Action left
                actionBox.transform.position = player.transform.position + LEFTPOINT;
                    SetAnimation(actionLeft);
                }
            if (playerMove.getState() == 3)
            {
                //Action Right
                actionBox.transform.position = player.transform.position + RIGHTPOINT;
                    SetAnimation(actionRight);
            }
            }
        }
    }

    private void CheckRestAnimantion()
    { 
            if (playerMove.getState() == 0)
            {
            //Action up down
            SetAnimation(playerMove.downSprites[0]);
            }
            if (playerMove.getState() == 1)
            {
            //Action Up
            SetAnimation(playerMove.upSprites[0]);
        }
            if (playerMove.getState() == 2)
            {
            //Action left
            SetAnimation(playerMove.leftSprites[0]);
        }
            if (playerMove.getState() == 3)
            {
            //right
            SetAnimation(playerMove.rightSprites[0]);
        }
        }
    private void SetAnimation(Sprite sprite)
    {
        spr.sprite = sprite;
    }
}
