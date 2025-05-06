using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupClient : MonoBehaviour
{
    private void OnEnable()
    {
        ServiceLocator.Initialize();

        PowerupDebugger debugger = FindObjectOfType<PowerupDebugger>();
        if (debugger != null)
        {
            ServiceLocator.RegisterLogger(debugger);
        }
        else
        {
            Debug.LogWarning("PowerupDebugger not found in scene.");
        }
    }

}

