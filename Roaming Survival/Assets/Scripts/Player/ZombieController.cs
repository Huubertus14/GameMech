using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{

    public float health = 100;
    public float damage = 10f;

    private GameObject player;
    private SpriteRenderer spr;
    private Rigidbody2D rb;

    private Vector3 direction;
    public Vector2 distancePlayerVector;
    public float distancePlayerLength;

    //All Idle value
    public Sprite[] idleSprites = new Sprite[6];
    private float idleCounter = 0;
    private float idleTimer = 6;

    //All walk value
    public Sprite[] walkSprites = new Sprite[10];
    private float walkCounter = 0;
    private float walkTimer = 10;

    private bool seesPlayer = false;

    //Death value
    public Sprite[] deathSprites = new Sprite[8];
    public bool isZombieDead = false;
    private float deadCounter = 8;

    //Attack value
    public Sprite[] attackSprites = new Sprite[7];
    public bool isAttacking = false;
    public float attackCounter = 7;
    public float attackTimer = 7;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        spr = gameObject.GetComponentInChildren<SpriteRenderer>();
        health = 100f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get the distance to player
        distancePlayerVector = player.transform.position - transform.position;
        distancePlayerLength = distancePlayerVector.magnitude;

        CheckState();

        //health -= 10 * Time.deltaTime;

        if(health <= 0)
        {
            //Zombie dead
            isZombieDead = true;
        }
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
        if (isZombieDead)
        {
            //This if the zombie is dead
            Dying();
        }
        else
        {
            //Do this if the zombie is still alive
            if (seesPlayer)
            {
                if (!isAttacking) {
                    //The zombie chases the player
                    ChasePlayer();
                }else
                {
                    //Attack
                    Attack();
                }
            }
            if (!seesPlayer)
            {
                //The zombie doesnt chase the player
                Idle();
            }
        }
    }

    private void Attack()
    {
        rb.velocity = new Vector2(0,0);

        attackCounter -= 11f * Time.deltaTime;

        if(attackCounter > 6)
        {
            SetSprite(attackSprites[0]);
        }else
            if (attackCounter > 5)
        {
            SetSprite(attackSprites[1]);
        }
        else
            if (attackCounter > 4)
        {
            SetSprite(attackSprites[2]);
        }
        else
            if (attackCounter > 3)
        {
            SetSprite(attackSprites[3]);
        }
        else if(attackCounter > 2)
        {
            SetSprite(attackSprites[4]);
            //Hit the player
            if (distancePlayerLength < 1.5f)
            {
                PlayerHit(damage);
            }
        }
        else if(attackCounter > 1)
        {
            SetSprite(attackSprites[5]);
        }else if (attackCounter > 0)
        {
            SetSprite(attackSprites[6]);
        }else if(attackCounter > -1)
        {
            isAttacking = false;
            attackCounter = attackTimer;
        }
    }

    private void Dying()
    {
        rb.velocity = new Vector2(0,0);
        //Here dies the zombie
        deadCounter -= 7f * Time.deltaTime;

        if(deadCounter > 7)
        {
            SetSprite(deathSprites[0]);
        }
        else
        if (deadCounter > 6)
        {
            SetSprite(deathSprites[1]);
        }
        else
        if (deadCounter > 5)
        {
            SetSprite(deathSprites[2]);
        }
        else
        if (deadCounter > 4)
        {
            SetSprite(deathSprites[3]);
        }
        else
        if (deadCounter > 3)
        {
            SetSprite(deathSprites[4]);
        }
        else
        if (deadCounter > 2)
        {
            SetSprite(deathSprites[5]);
        }
        else
        if (deadCounter > 1)
        {
            SetSprite(deathSprites[6]);
        }
        else
        if (deadCounter > 0)
        {
            SetSprite(deathSprites[7]);
        }else if (deadCounter > -1)
        {
            Destroy(gameObject);
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //PlayerHit(damage);
            isAttacking = true;
        }
    }

    private void PlayerHit(float givenDamage)
    {
        //Damage the player
        player.GetComponent<PlayerController>().PlayerDamage(givenDamage);
        distancePlayerVector.x = player.transform.position.x - transform.position.x;
        distancePlayerVector.y = player.transform.position.y - transform.position.y;
        distancePlayerVector.Normalize();

        player.GetComponent<Rigidbody2D>().AddForce(distancePlayerVector * 5000);
    }
}