using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePowerup : ICommand
{
    private PlayerMovement player;

    public RemovePowerup(PlayerMovement player)
    {
        this.player = player;
    }
    public void Execute()
    {
        player.movementStrategy = new DefaultStrategy();
    }

}
