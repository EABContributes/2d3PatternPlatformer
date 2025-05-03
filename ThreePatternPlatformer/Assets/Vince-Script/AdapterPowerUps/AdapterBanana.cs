using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdapterBanana : INewPowerUp
{
    public void ActivateNewPowerUp(PlayerMovement player)
    {
        player.movementStrategy = new BananaStrategy();
    }
}
