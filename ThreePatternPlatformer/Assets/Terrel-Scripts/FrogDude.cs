// Written By Terrel
// 3/20/2025
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDude : Enemy
{
    private FrogMovement frogMovement;
    public override void Initialize()
    {
        Debug.Log("FrogDude Spawned!");
    }

    public void InitializeBounds(float leftOffset, float rightOffset)
    {
        if (frogMovement == null)
        {
            frogMovement = GetComponent<FrogMovement>();
        }

            if (frogMovement == null)
            {
                Debug.LogError("FrogMovement component is missing on FrogDude!");
                return; // Stop execution to avoid the null reference error.
            }
        

        float spawnX = transform.position.x; // Get the spawn position X
        frogMovement.leftBound = spawnX + leftOffset; // Make bounds relative aka based off spawn location rather than world position
        frogMovement.rightBound = spawnX + rightOffset;
        Debug.Log($"FrogDude Spawned at {spawnX}. Left Bound: {frogMovement.leftBound}, Right Bound: {frogMovement.rightBound}");
    }
}
