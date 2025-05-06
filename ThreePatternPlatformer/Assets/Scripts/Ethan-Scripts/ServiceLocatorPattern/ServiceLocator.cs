using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
//Ethan Blomgren
public class ServiceLocator : MonoBehaviour
{
    private static IPowerupLogContract logging;

    private static IPowerupLogContract nullPowerupLogger = new NullPowerupLogger();

    public static void Initialize()
    {
        logging = nullPowerupLogger;
    }


    public static void RegisterLogger(IPowerupLogContract service)
    {
        logging = service;
        Debug.Log("Registered Powerup Logging Service.");
    }

    public static IPowerupLogContract GetPowerupLogService()
    {
        return logging;
    }
}
