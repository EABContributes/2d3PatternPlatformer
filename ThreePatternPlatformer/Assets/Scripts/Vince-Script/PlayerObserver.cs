using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    public delegate void PlayerPlacement(Vector3 newPosition);
    public event PlayerPlacement OnPlayerPlacement;

    void Update()
    {
        AlertObserver(transform.position);
    }

    public void AlertObserver(Vector3 newPosition)
    {
        if (OnPlayerPlacement != null)
        {
            OnPlayerPlacement(newPosition);
        }
    }
}