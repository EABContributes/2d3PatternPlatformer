using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Vince Herrera
 */
public class AppleStrategy : MovementStrategy
{
    public float GetSpeed()
    {
        return 5f;
    }
    public float GetJumpForce()
    {
        return 15f;
    }
}
