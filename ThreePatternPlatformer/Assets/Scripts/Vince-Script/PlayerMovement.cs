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
    private PlayerObserver playerPlacement;
    public AudioSource jumpSound;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        movementStrategy = new DefaultStrategy();
        objectPool = FindObjectOfType<ObjectPool>();
        manager = FindObjectOfType<Manager>();
        playerPlacement = GetComponent<PlayerObserver>();
    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");
        //if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        if (Input.GetButtonDown("Jump") && movementStrategy.CanJump(rb, coll, ground)) // Changed this line to fix double jump
        {
            rb.velocity = new Vector2(rb.velocity.x, movementStrategy.GetJumpForce());
            movementStrategy.OnJump(); //Added in this line to make double jump work properly
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ExecuteCommand(new RemovePowerup(this));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExecuteCommand(new PauseCommand());
        }
        if (playerPlacement != null)
        {
            playerPlacement.AlertObserver(transform.position);
        }
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

    //added in this method so that there isn't repeated code under each individual powerup --TW
    //Below Method ensures that doublejump is not lost when picking up another powerup
    public void ApplyPowerUp(MovementStrategy newStrategy, GameObject powerUpObject, Vector2 position)
    {
        if (movementStrategy is DoubleJumpDecorator)
        {
            movementStrategy = new DoubleJumpDecorator(newStrategy, coll, ground);
        }
        else
        {
            movementStrategy = newStrategy;
        }

        if (objectPool != null)
        {
            objectPool.ReturnToPool(powerUpObject);
            StartCoroutine(RespawnPowerUp(position));
        }
        else
        {
            Destroy(powerUpObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //INewPowerUp powerUp = null;
        if (collision.tag == "Cherry")
        {
            //powerUp = new AdapterCherry();
            INewPowerUp powerUp = new AdapterCherry(collision.gameObject);
            powerUp.ActivateNewPowerUp(this);
            
        }
        else if (collision.tag == "Banana")
        {
            //powerUp = new AdapterBanana();
            INewPowerUp powerUp = new AdapterBanana(collision.gameObject);
            powerUp.ActivateNewPowerUp(this);
            
        }
        else if (collision.tag == "Apple")
        {
            //powerUp = new AdapterApple();
            INewPowerUp powerUp = new AdapterApple(collision.gameObject);
            powerUp.ActivateNewPowerUp(this);

        }
        else if (collision.tag == "Melon")
        {
            //powerUp = new AdapterMelon();
            INewPowerUp powerUp = new AdapterMelon(collision.gameObject);
            powerUp.ActivateNewPowerUp(this);
        }
        else if (collision.CompareTag("Strawberry"))
        {
            movementStrategy = new DoubleJumpDecorator(movementStrategy, coll, ground);

            if (objectPool != null)
            {
                objectPool.ReturnToPool(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
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
    private void ExecuteCommand(ICommand command)
    {
        command.Execute();
    }
}
