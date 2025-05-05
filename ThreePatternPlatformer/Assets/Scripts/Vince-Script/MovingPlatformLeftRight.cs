using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeftRight : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 3.0f;
    public float waitTime = 1.0f;

    private Vector3 startPos;
    private bool movingRight = true;
    private bool waiting = false;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        if (!waiting)
        {
            if (movingRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x >= startPos.x + distance)
                {
                    movingRight = false;
                    StartCoroutine(WaitAtEnd());
                }
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (transform.position.x <= startPos.x - distance)
                {
                    movingRight = true;
                    StartCoroutine(WaitAtEnd());
                }
            }
        }
    }

    private IEnumerator WaitAtEnd()
    {
        waiting = true;
        yield return new WaitForSeconds(waitTime);
        waiting = false;
    }
}
