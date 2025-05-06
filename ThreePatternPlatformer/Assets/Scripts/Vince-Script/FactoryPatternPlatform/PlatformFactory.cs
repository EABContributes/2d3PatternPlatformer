using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : InterfacePlatformFactory
{
    private GameObject platformPrefab;

    public PlatformFactory(GameObject prefab)
    {
        platformPrefab = prefab;
    }
    public GameObject CreatePlatform()
    {
        GameObject platform = Object.Instantiate(platformPrefab);
        platform.SetActive(false);
        return platform;
    }
}
