using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{

    private GameObject player;
    private SpriteRenderer spr;
    private Rigidbody2D rb;

    public Vector3 direction;

    public Sprite[] idleSprites = new Sprite[6];
    private float idleCounter = 0;
    private float idleTimer = 6;

    public Sprite[] walkSprites = new Sprite[10];
    private float walkCounter = 0;
    private float walkTimer = 10;

    public bool seesPlayer = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        spr = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckState();
    }

    private void Idle()
    {
        //Randomly walks around???

        rb.velocity = new Vector2(0,0);
        idleCounter += 10f * Time.deltaTime;
        if (idleCounter > idleTimer)
        {
            idleCounter = 0;
        }

        IdleAnimation();
    }

    private void CheckState()
    {
        if (seesPlayer)
        {
            ChasePlayer();
        }
        if(!seesPlayer){
            Idle();
        }
    }

    private void ChasePlayer()
    {
            direction = player.transform.position - transform.position;
            direction.Normalize();

            rb.velocity = direction * 0.5f;
        //Needs to reset 

            WalkAnimation();
    }

    private void IdleAnimation()
    {
        if (idleCounter > 5)
        {
            SetSprite(idleSprites[0]);
        }
        else
        if (idleCounter > 4)
        {
            SetSprite(idleSprites[1]);
        }
        else
        if (idleCounter > 3)
        {
            SetSprite(idleSprites[2]);
        }
        else
        if (idleCounter > 2)
        {
            SetSprite(idleSprites[3]);
        }
        else
        if (idleCounter > 1)
        {
            SetSprite(idleSprites[4]);
        }
        else
        if (idleCounter > 0)
        {
            SetSprite(idleSprites[5]);
        }
    }

    private void WalkAnimation()
    {
        if(player.transform.position.x > transform.position.x)
        {
            spr.flipX = true;
        }else
        {
            spr.flipX = false;
        }

        walkCounter += 10 * Time.deltaTime;
        if(walkCounter > walkTimer)
        {
            walkCounter = 0;
        }
        if(walkCounter > 9)
        {
            SetSprite(walkSprites[9]);
        }
        else
        if (walkCounter > 8)
        {
            SetSprite(walkSprites[8]);
        }
        else
        if (walkCounter > 7)
        {
            SetSprite(walkSprites[7]);
        }
        else
        if (walkCounter > 6)
        {
            SetSprite(walkSprites[6]);
        }
        else
        if (walkCounter > 5)
        {
            SetSprite(walkSprites[5]);
        }
        else
        if (walkCounter > 4)
        {
            SetSprite(walkSprites[4]);
        }
        else
        if (walkCounter > 3)
        {
            SetSprite(walkSprites[3]);
        }
        else
        if (walkCounter > 2)
        {
            SetSprite(walkSprites[2]);
        }
        else
        if (walkCounter > 1)
        {
            SetSprite(walkSprites[1]);
        }
        else
        if (walkCounter > 0)
        {
            SetSprite(walkSprites[0]);
        }
    }

    private void SetSprite(Sprite sprite)
    {
        spr.sprite = sprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //The zombie sees the player
            seesPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //The zombie sees the player
            seesPlayer = false;
        }
    }
}