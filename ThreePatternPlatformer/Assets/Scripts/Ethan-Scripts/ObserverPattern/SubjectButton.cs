using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Ethan Blomgren

public class SubjectButton : MonoBehaviour
{
    private List<IBtnObserver> observers = new List<IBtnObserver>();

    //subscribe objects (platforms) to the observation subject
    public void RegisterObserver(IBtnObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }
    //unsubscribe objects from the observation subject
    public void UnregisterObserver(IBtnObserver observer) {

        if (observers.Contains(observer)) 
        {
            observers.Remove(observer);
        }

    }

    public void NotifyBtnActivation()
    {
        foreach (var observer in observers) 
        {
            observer.onButtonActivated();
        }
    }
    public void NotifyBtnDeactivation()
    {
        foreach (var observer in observers)
        {
            observer.onButtonDeactivated();
        }
    }
}
