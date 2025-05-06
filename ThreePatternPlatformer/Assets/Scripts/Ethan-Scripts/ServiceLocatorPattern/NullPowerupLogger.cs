using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullPowerupLogger : IPowerupLogContract
{
    public void Log(string message)
    {
        Debug.LogWarning(GetType().Name + " Null Powerup Logger! ");
    }

    public void Throw(string message)
    {
        Debug.LogWarning(GetType().Name + " null Powerup Logger! ");
    }
}
