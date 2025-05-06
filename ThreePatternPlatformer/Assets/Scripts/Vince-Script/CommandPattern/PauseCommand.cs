using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCommand : ICommand
{
    public void Execute()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
