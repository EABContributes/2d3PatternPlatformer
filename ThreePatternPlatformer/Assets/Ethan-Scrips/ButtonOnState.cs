using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ButtonOnState : IButtonState
{
    private float duration = 5.0f;
    private float timer;
    
    public void EnterState(ButtonTile aButtonTile)
    {
        Debug.Log("Entering On State");
        aButtonTile.redStateRenderer.enabled = false;
        timer = duration;
        if (aButtonTile.secretPlatform != null)
        {
            aButtonTile.secretPlatform.SetActive(true);
        }
    }

    public void ExecuteState(ButtonTile aButtonTile)
    {
        timer = timer - Time.deltaTime;
        if (timer <=0) aButtonTile.ChangeState(new ButtonOffState());
    }

    public void ExitState(ButtonTile aButtonTile)
    {
        Debug.Log("On State Ending");
    }
}
