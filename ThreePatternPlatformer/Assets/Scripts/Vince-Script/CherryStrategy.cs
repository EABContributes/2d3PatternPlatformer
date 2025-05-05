//Edited By Terrel
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Vince Herrera
 */
public class CherryStrategy : MovementStrategy
{
    public float GetSpeed()
    {
        return 7.5f;
    }
    public float GetJumpForce()
    {
        return 10f;
    }
    //Below code was added to make double jump properly work TW
    public bool CanJump(Rigidbody2D rb, Collider2D coll, LayerMask ground)
    {
        return coll.IsTouchingLayers(ground);
    }
    public void OnJump()
    {

    }
}
