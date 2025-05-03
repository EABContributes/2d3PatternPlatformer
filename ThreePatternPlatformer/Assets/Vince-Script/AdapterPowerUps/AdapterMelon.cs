using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdapterMelon : INewPowerUp
{
    public void ActivateNewPowerUp(PlayerMovement player)
    {
        player.movementStrategy = new MelonStrategy();
    }
}
