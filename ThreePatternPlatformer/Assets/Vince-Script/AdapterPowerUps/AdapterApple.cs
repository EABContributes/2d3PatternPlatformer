using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdapterApple : INewPowerUp
{
    public void ActivateNewPowerUp(PlayerMovement player)
    {
        player.movementStrategy = new AppleStrategy();
    }
}
