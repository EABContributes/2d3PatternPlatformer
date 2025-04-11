using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//Ethan Blomgren
public class ButtonOffState2 : IButtonState2
{

    public void EnterState2(ButtonTile2 aButtonTile)
    {
        aButtonTile.redStateRenderer2.enabled = true;
        Debug.Log("Button Off 2");
        aButtonTile.buttonSubject.NotifyBtnDeactivation();
    }

    public void ExecuteState2(ButtonTile2 aButtonTile)
    {

    }

    public void ExitState2(ButtonTile2 aButtonTile)
    {
        Debug.Log("Button no longer off 2");
    }
}
