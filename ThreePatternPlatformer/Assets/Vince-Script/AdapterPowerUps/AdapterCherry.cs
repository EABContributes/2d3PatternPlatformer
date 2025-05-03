using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdapterCherry : INewPowerUp
{
    public void ActivateNewPowerUp(PlayerMovement player)
    {
        player.movementStrategy = new CherryStrategy();
    }
}
