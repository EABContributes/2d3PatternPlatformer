using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ButtonOnState2 : IButtonState2
{
    private float duration = 8.0f;
    private float timer;

    public void EnterState2(ButtonTile2 aButtonTile)
    {
        Debug.Log("Entering On State 2");
        aButtonTile.redStateRenderer2.enabled = false;
        timer = duration;
        aButtonTile.buttonSubject.NotifyBtnActivation();
    }

    public void ExecuteState2(ButtonTile2 aButtonTile)
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0) aButtonTile.ChangeState2(new ButtonOffState2());
    }

    public void ExitState2(ButtonTile2 aButtonTile)
    {
        Debug.Log("On State Ending 2");
    }
}
