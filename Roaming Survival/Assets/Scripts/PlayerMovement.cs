using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    /*
     * This script is used to detect the movement of the player
     * This wil also detects any actions the player makes like chopping wood or attacking
 
     */



    private Rigidbody2D rb;
    private float speed = 1;
    private float movementSpeed = 0;

    public float sprintSpeed = 0.9f;
    public float walkSpeed = 0.5f;

    private bool iswalking;

    //0 = down
    //1 = up
    //2 = left
    //3 = rigth

    private int state = 0;


    private SpriteRenderer spr;
    private float animationSpeed = 5;

    public Sprite[] downSprites = new Sprite[4];
    public Sprite[] upSprites = new Sprite[4];
    public Sprite[] leftSprites = new Sprite[4];
    public Sprite[] rightSprites = new Sprite[4];

    public float animationCounter = 0;
    // Use this for initialization
    void Awake () {
        //Walkingspeed
        movementSpeed = 0.5f;
       
        spr = gameObject.GetComponentInChildren<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        MovementSet();
        PlayerAnimation();
    }

    private void PlayerAnimation()
    {
            //Check the state and call the animations for that kind of sprite set & state
            if (state == 0)
            {
                FixedPlayerAnimation(downSprites);
            }
            else if (state == 1)
            {
                FixedPlayerAnimation(upSprites);
            }
            else if (state == 2)
            {
                FixedPlayerAnimation(leftSprites);
            }
            else if (state == 3)
            {
                FixedPlayerAnimation(rightSprites);
            }
        

    }
    

    private void FixedPlayerAnimation(Sprite[] sprites)
    {
        //down move animation
        if (animationCounter > 3)
        {
            spr.sprite = sprites[3];
        }
        else if (animationCounter > 2)
        {
            spr.sprite = sprites[2];
        }
        else if (animationCounter > 1)
        {
            spr.sprite = sprites[1];
        }
        else if (animationCounter > 0)
        {
            spr.sprite = sprites[0];
        }
    }

    private void SprintFunction()
    {
        //Checks if sprinting or not
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementSpeed = sprintSpeed;
                animationSpeed = movementSpeed * 10;
            }
            else
            {
                movementSpeed = walkSpeed;
                animationSpeed = movementSpeed * 10;
            } 
    }

    private void MovementSet()
    {
        SprintFunction();
        MovementForce();
        AnimationInput();
    }
    
    private void AnimationInput()
    {
        if (!Input.GetKey("d") && !Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a"))
        {
            iswalking = false;
            rb.velocity = new Vector2(0, 0);
            animationCounter = 0;
            PlayerAnimation();
        }
        else
        {
            iswalking = true;
            animationCounter += animationSpeed * Time.deltaTime;
            if (animationCounter > 3.9f)
            {
                animationCounter = 0;
            }
        }
    }

    private void MovementForce()
    {
        if (Input.GetKey("w"))
        {
            //Up
            rb.velocity = new Vector2(rb.velocity.x, movementSpeed);
            state = 1;
        }

        if (Input.GetKey("a"))
        {
            //Left
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            state = 2;
        }

        if (Input.GetKey("s"))
        {
            //Down
            rb.velocity = new Vector2(rb.velocity.x, -movementSpeed);
            state = 0;
        }

        if (Input.GetKey("d"))
        {
            //Right
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            state = 3;
        }
    }

    public int getState()
    {

        return state;
    }

    public bool checkIfWalking()
    {
        return iswalking;
    }
}
