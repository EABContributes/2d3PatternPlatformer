// Written By Terrel
// 3/20/2025
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStomp : MonoBehaviour
{
    public float bounce;
    public Rigidbody2D rb2D;
    //[SerializeReference]AudioSource myAudioSource; //Sound will be handled by Sound Mediator

    // Start is called before the first frame update
    void Start()
    {
        //myAudioSource = GetComponent<AudioSource>(); // Sound will be handled by Sound Mediator
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            SoundMediator.Instance.PlayStompSound();
            rb2D.velocity = new Vector2(rb2D.velocity.x, bounce);
        }
    }
}
