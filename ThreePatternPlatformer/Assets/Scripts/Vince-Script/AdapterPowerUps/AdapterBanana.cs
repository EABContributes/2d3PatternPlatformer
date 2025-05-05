//Edited By Terrel Woitas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdapterBanana : INewPowerUp
{
    private GameObject powerUpObject;
    //Added in above variable and below method so that ApplyPowerUp would have necessary parameters
    public AdapterBanana(GameObject gameObject)
    {
        powerUpObject = gameObject;
    }
    public void ActivateNewPowerUp(PlayerMovement player)
    {
        //player.movementStrategy = new BananaStrategy();

        player.ApplyPowerUp(new BananaStrategy(),powerUpObject,powerUpObject.transform.position);
        //Modified above line to use the ApplyPowerUp method to check if double jump is already active TW
    }
}
