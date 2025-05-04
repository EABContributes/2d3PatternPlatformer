// Written By Terrel
// 3/20/2025
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyFactory.Instance.SpawnEnemy("FrogDude", new Vector2(17, -12), -3, 5);
        }
    }
}
