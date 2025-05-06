using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ButtonTile2 : MonoBehaviour
{
    private IButtonState2 currentState2;
    public TilemapRenderer redStateRenderer2;
    public SubjectButton buttonSubject;
    public AudioSource buttonSound;
    public AudioSource alarmSound;
    private void Start()
    {
        redStateRenderer2 = GetComponent<TilemapRenderer>();
        redStateRenderer2.sortingOrder = 6;
        currentState2 = GetComponent<IButtonState2>();
        if (redStateRenderer2 == null)
        {
            redStateRenderer2 = gameObject.AddComponent<TilemapRenderer>();

        }
        ChangeState2(new ButtonOffState2());

    }
    private void Update()
    {
        if (currentState2 != null)
        {
            currentState2.ExecuteState2(this);
        }
    }
    public void ChangeState2(IButtonState2 nextState)
    {
        if (currentState2 != null)
        {
            currentState2.ExitState2(this);
        }
        currentState2 = nextState;
        currentState2.EnterState2(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision Met 2");
            this.ChangeState2(new ButtonOnState2());
            buttonSound.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision Met 2");
            this.ChangeState2(new ButtonOnState2());
            buttonSound.Play();
        }
    }
}
