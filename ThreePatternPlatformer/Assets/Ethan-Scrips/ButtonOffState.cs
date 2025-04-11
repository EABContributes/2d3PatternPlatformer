using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//Ethan Blomgren
public class ButtonOffState : IButtonState
{
    
    public void EnterState(ButtonTile aButtonTile)
    {
        aButtonTile.redStateRenderer.enabled = true;
        Debug.Log("Button Off");
        if (aButtonTile.secretPlatform != null)
        {
            aButtonTile.secretPlatform.SetActive(false);
        }
    }

    public void ExecuteState(ButtonTile aButtonTile)
    {
        
    }

    public void ExitState(ButtonTile aButtonTile)
    {
        Debug.Log("Button no longer off");
    }
}
