using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStrategy : MovementStrategy
{
    public float GetSpeed()
    {
        return 5f;
    }
    public float GetJumpForce()
    {
        return 10f;
    }
}

