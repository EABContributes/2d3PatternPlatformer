using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ButtonTile : MonoBehaviour
{
    private IButtonState currentState;
    public TilemapRenderer redStateRenderer;
    public GameObject secretPlatform;
    [SerializeReference] public AudioSource buttonSound;
    public AudioSource alarmSound;
    private void Start()
    {
        redStateRenderer = GetComponent<TilemapRenderer>();
        redStateRenderer.sortingOrder = 6;
        if (redStateRenderer == null)
        {
            redStateRenderer = gameObject.AddComponent<TilemapRenderer>();
            
        }
        ChangeState(new ButtonOffState());

    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.ExecuteState(this);
        }
    }
    public void ChangeState(IButtonState nextState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = nextState;
        currentState.EnterState(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision Met");
            this.ChangeState(new ButtonOnState());
            buttonSound.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision Met");
            this.ChangeState(new ButtonOnState());
            buttonSound.Play();
        }
    }
}
