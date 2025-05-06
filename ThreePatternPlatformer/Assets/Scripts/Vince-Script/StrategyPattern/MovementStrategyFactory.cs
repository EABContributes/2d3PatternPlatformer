using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Vince Herrera
 */
public static class MovementStrategyFactory
{
    public static MovementStrategy GetStrategy(string aPowerUpTag)
    {
        MovementStrategy strategy = null;
        switch(aPowerUpTag)
        {
            case "Cherry":
                strategy = new CherryStrategy();
                break;
            case "Banana":
                strategy = new BananaStrategy();
                break;
            case "Apple":
                strategy = new AppleStrategy();
                break;
            default:
                strategy = new DefaultStrategy();
                break;
        }
        return strategy;
    }
}