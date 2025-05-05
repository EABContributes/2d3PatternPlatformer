using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObserver : MonoBehaviour, IBtnObserver
{
    private void Awake()
    {
        SubjectButton button = FindObjectOfType<SubjectButton>();
        if (button != null) {
            button.RegisterObserver(this);
        }
    }
    public void onButtonActivated()
    {
        gameObject.SetActive(false);
    }

    public void onButtonDeactivated()
    {
        gameObject.SetActive(true);
    }

}
