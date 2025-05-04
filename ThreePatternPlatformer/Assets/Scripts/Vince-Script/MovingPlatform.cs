using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] public float speed = 2.0f;
    [SerializeField] public float distance = 3.0f;
    [SerializeField] public float waitTime = 1.0f;
    // Start is called before the first frame update

    private Vector3 startPosition;
    private bool movingUp = true;
    private bool waiting = false;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            if (movingUp)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
                if (transform.position.y >= startPosition.y + distance)
                {
                    movingUp = false;
                    StartCoroutine(WaitAtTop());
                }
            }
            else
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
                if (transform.position.y <= startPosition.y - distance)
                {
                    movingUp = true;
                    StartCoroutine(WaitAtTop());
                }
            }
        }
    }
    private IEnumerator WaitAtTop()
    {
        waiting = true;
        yield return new WaitForSeconds(waitTime);
        waiting = false;
    }
}
