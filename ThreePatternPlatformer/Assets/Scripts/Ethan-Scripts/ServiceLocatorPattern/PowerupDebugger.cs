using System;
using TMPro;
using UnityEngine;

public class PowerupDebugger : MonoBehaviour, IPowerupLogContract
{
    

    public TextMeshProUGUI messageDisplay;



    public void Log(string message)
    {
        string formatted = "Powerup: " + message;
        if (messageDisplay != null)
            messageDisplay.text = formatted;
        else
            Debug.LogWarning("PowerupDebugger: TMP not assigned!");
    }

    public void Throw(string message)
    {
        string formatted = "Message thrown at: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + message;
        if (messageDisplay != null)
            messageDisplay.text = formatted;
        else
            Debug.LogWarning("PowerupDebugger: TMP not assigned!");
    }
}
