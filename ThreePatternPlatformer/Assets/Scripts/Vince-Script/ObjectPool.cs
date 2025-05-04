using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Vince Herrera
 */
public class ObjectPool : MonoBehaviour
{
    public GameObject[] powerUps;
    public int poolSize = 3;
    private List<GameObject> pool;

    void Start()
    {
        pool = new List<GameObject>();
        foreach (var prefab in powerUps)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                pool.Add(obj);
            }
        }
        SpawnFirstPowerUp();
    }

    public GameObject GetPooledObject(string tag)
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy && obj.tag == tag)
            {
                return obj;
            }
        }
        return null;
    }
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void SpawnPowerUp(Vector2 position)
    {
        List<GameObject> inactivePowerUps = new List<GameObject>();
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                inactivePowerUps.Add(obj);
            }
        }
        if (inactivePowerUps.Count > 0)
        {
            GameObject powerUp = inactivePowerUps[Random.Range(0, inactivePowerUps.Count)];
            powerUp.transform.position = position;
            powerUp.SetActive(true);
        }
    }
    private void SpawnFirstPowerUp()
    {
        Vector2 firstPosition = new Vector2(Random.Range(2f, 18f), Random.Range(-3f, 4f));
        Vector2 secondPosition = new Vector2(Random.Range(34f, 34f), Random.Range(8f, 8f));
        SpawnPowerUp(firstPosition);
        SpawnPowerUp(secondPosition);
    }
}
