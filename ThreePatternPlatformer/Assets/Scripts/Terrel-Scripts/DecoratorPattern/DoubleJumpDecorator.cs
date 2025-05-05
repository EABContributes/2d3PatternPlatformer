// Written By Terrel Woitas
// Other Scripts That were changed to make this decorator work Vince-Scripts/MovementStrategy, DefaultStrategy, CherryStrategy, BananaStrategy, AppleStrategy,
// MelonStrategy, AdapterCherry, AdapterBanana, AdapterApple, AdapterMelon
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpDecorator : MovementStrategy
{
    private MovementStrategy baseStrategy;
    private int jumpCount = 0;
    private int maxJumps = 2;

    private Collider2D collider;
    private LayerMask ground;

    public DoubleJumpDecorator(MovementStrategy baseStrategy, Collider2D collider, LayerMask ground)
    {
        this.baseStrategy = baseStrategy;
        this.collider = collider;
        this.ground = ground;
    }

    public float GetSpeed() => baseStrategy.GetSpeed();
    public float GetJumpForce() => baseStrategy.GetJumpForce();

    public bool CanJump(Rigidbody2D rb, Collider2D collider, LayerMask ground)
    {
        if (collider.IsTouchingLayers(ground))
        {
            jumpCount = 0;
            return true;
        }
        return jumpCount < maxJumps;
    }

    public void OnJump()
    {
        jumpCount++;
        baseStrategy.OnJump();
    }
}
