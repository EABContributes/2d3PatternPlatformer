//Edited by Terrel
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Vince Herrera
 */
public interface MovementStrategy
{
    float GetSpeed();
    float GetJumpForce();
    
    //added the following for the Double Jump Decorator to work
    bool CanJump(Rigidbody2D rb, Collider2D coll, LayerMask ground);
    void OnJump();

}
