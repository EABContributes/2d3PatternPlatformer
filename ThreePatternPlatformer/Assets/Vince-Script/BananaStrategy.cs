using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaStrategy : MovementStrategy
{
    public float GetSpeed()
    {
        return 7.5f;
    }
    public float GetJumpForce()
    {
        return 15f;
    }
}
