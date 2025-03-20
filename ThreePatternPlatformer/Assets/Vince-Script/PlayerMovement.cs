using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

/*
 * Vince Herrera
 */

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public enum State { idle, run, jump, falling };
    public State state = State.idle;
    public Collider2D coll;
    [SerializeField] public LayerMask ground;
    [SerializeField] public MovementStrategy movementStrategy;
    private ObjectPool objectPool;
    private Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        movementStrategy = new DefaultStrategy();
        objectPool = FindObjectOfType<ObjectPool>();
        manager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, movementStrategy.GetJumpForce());
            state = State.jump;
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
            objectPool.ReturnToPool(collision.gameObject);
            StartCoroutine(RespawnPowerUp(collision.transform.position));
        }
        else if (collision.tag == "Banana")
        {
            movementStrategy = new BananaStrategy();
            objectPool.ReturnToPool(collision.gameObject);
            StartCoroutine(RespawnPowerUp(collision.transform.position));
        }
        else if (collision.tag == "Apple")
        {
            movementStrategy = new AppleStrategy();
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
