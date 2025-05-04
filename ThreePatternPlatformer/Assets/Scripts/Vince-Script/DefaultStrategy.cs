//Edited by Terrel
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Vince Herrera
 */
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
    //Below code is for the Decorator Pattern to work
    public bool CanJump(Rigidbody2D rb, Collider2D coll, LayerMask ground)
    {
        return coll.IsTouchingLayers(ground);
    }

    public void OnJump() 
    { 
        // There is no change for the default strategy  
    }



}

