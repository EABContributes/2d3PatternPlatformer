// Written By Terrel
// 3/20/2025
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [SerializeField] public float leftBound;
    [SerializeField] public float rightBound;
    [SerializeField] public LayerMask Ground;
    [SerializeField] public float speed;

    public bool right = true;


    public Rigidbody2D rb;
    public Collider2D coll;

    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (right)
        {
            if (transform.position.x < rightBound)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                right = false;
            }
        }
        else
        {
            if (transform.position.x > leftBound)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                right = true;
            }
        }

    }
}
