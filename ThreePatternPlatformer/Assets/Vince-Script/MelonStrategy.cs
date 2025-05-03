using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonStrategy : MovementStrategy
{
    public float GetSpeed()
    {
        return 7f;
    }
    public float GetJumpForce()
    {
        return 12f;
    }
}
