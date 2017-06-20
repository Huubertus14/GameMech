using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    /*
     * This script is used to detect the movement of the player
     * This wil also detects any actions the player makes like chopping wood of attacking
 
     */

    private Rigidbody2D rb;
    private float speed = 1;

    //0 = down
    //1 = up
    //2 = left
    //3 = rigth

    private int state = 0;
    private SpriteRenderer spr;
    private int animationSpeed = 5;

    public Sprite[] downSprites = new Sprite[4];
    public Sprite[] upSprites = new Sprite[4];
    public Sprite[] leftSprites = new Sprite[4];
    public Sprite[] rightSprites = new Sprite[4];

    public float animationCounter = 0;
    // Use this for initialization
    void Awake () {
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


    void MovementSet()
    {
        if (Input.GetKey("w"))
        {
            //Up
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
            state = 1;
        }

        if (Input.GetKey("a"))
        {
            //Left
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
            state = 2;
        }

        if (Input.GetKey("s"))
        {
            //Down
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
            state = 0;
        }

        if (Input.GetKey("d"))
        {
            //Right
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
            state = 3;
        }

        if(!Input.GetKey("d") && !Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a"))
        {
            animationCounter = 0;
        }else
        {
            animationCounter += animationSpeed * Time.deltaTime;
            if(animationCounter > 3.9f)
            {
                animationCounter = 0;
            }
        }
    }

    void MovementForce()
    {
        if (Input.GetKey("w"))
        {
            //Up
           rb.AddForce(Vector2.up * speed);

        }

        if (Input.GetKey("a"))
        {
            //Left
            rb.AddForce(-Vector2.right * speed);
        }

        if (Input.GetKey("s"))
        {
            //Down
            rb.AddForce(-Vector2.up * speed);
        }

        if (Input.GetKey("d"))
        {
            //Right
            rb.AddForce(Vector2.right * speed);
        }
    }
}
