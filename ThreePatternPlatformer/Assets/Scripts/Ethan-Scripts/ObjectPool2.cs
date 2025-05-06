using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Modified from Vince
by Ethan Blomgren
Changes made to render in the right place,
and to use the spriteRenderer to render on layer order 6
 */

public class ObjectPool2 : MonoBehaviour
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
            
            // to account for the parallax
            SpriteRenderer spriteRenderer = powerUp.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingLayerName = "Objects";
                spriteRenderer.sortingOrder = 6;
            }
        }
    }
    private void SpawnFirstPowerUp()
    {
        Vector2 firstPosition = new Vector2(Random.Range(4f, -3f), Random.Range(7f, 3f));
        SpawnPowerUp(firstPosition);
    }
}
