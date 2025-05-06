using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public enum State { idle, run, jump, falling };
    public State state = State.idle;
    public Collider2D coll;
    [SerializeField] public LayerMask ground;
    [SerializeField] public MovementStrategy movementStrategy;
    private ObjectPool2 objectPool;
    private Manager manager;
    public AudioSource jumpSound;
    IPowerupLogContract logging;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        movementStrategy = new DefaultStrategy();
        objectPool = FindObjectOfType<ObjectPool2>();
        manager = FindObjectOfType<Manager>();
        logging = ServiceLocator.GetPowerupLogService();

    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, movementStrategy.GetJumpForce());
            state = State.jump;
            jumpSound.Play();
        }
        else if (hDirection < 0)
        {
            rb.velocity = new Vector2(-movementStrategy.GetSpeed(), rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(movementStrategy.GetSpeed(), rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else if (coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        velocityState();
        anim.SetInteger("State", (int)state);
    }

    public void velocityState()
    {
        if (state == State.jump)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.run;
        }
        else
        {
            state = State.idle;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cherry")
        {
            movementStrategy = new CherryStrategy();
            logging.Log("Cherry");
            objectPool.ReturnToPool(collision.gameObject);
            StartCoroutine(RespawnPowerUp(collision.transform.position));
        }
        else if (collision.tag == "Banana")
        {
            movementStrategy = new BananaStrategy();
            logging.Log("Banana");
            objectPool.ReturnToPool(collision.gameObject);
            StartCoroutine(RespawnPowerUp(collision.transform.position));
        }
        else if (collision.tag == "Apple")
        {
            movementStrategy = new AppleStrategy();
            logging.Log("Apple");
            objectPool.ReturnToPool(collision.gameObject);
            StartCoroutine(RespawnPowerUp(collision.transform.position));
        }
        else if (collision.tag == "3Platform")
        {
            StartCoroutine(manager.HandlePlatform(collision.gameObject));
        }
    }

    public IEnumerator RespawnPowerUp(Vector2 position)
    {
        yield return new WaitForSeconds(5f);
        objectPool.SpawnPowerUp(position);
    }
}
