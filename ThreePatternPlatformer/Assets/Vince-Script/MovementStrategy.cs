using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MovementStrategy
{
    float GetSpeed();
    float GetJumpForce();
}
