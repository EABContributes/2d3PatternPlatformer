//Edited by Terrel Woitas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private List<GameObject> platforms;
    public GameObject blockPlatform;
    private Queue<GameObject> platformPool = new Queue<GameObject>();
    public int poolSize = 3;
    public string platformTag = "3Platform";
    private InterfacePlatformFactory PlatformFactory;
    //public AudioSource alarmSound; //commented this out because Sound Mediator will handle this TW

    void Start()
    {
        PlatformFactory = new PlatformFactory(blockPlatform);

        foreach (var prefab in platforms)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject platform = PlatformFactory.CreatePlatform();
                platform.tag = platformTag;
                platformPool.Enqueue(platform);
            }
        }
    }

    public void SpawnPlatform(Vector2 position)
    {
        GameObject platform = GetPlatform();
        platform.transform.position = position;
        platform.SetActive(true);
        SoundMediator.Instance.PlayAlarmSound();
    }

    public void DespawnPlatform(GameObject platform)
    {
        platform.SetActive(false);
        platformPool.Enqueue(platform);
    }

    public GameObject GetPlatform()
    {
        if (platformPool.Count > 0)
        {
            return platformPool.Dequeue();
        }
        else
        {
            return PlatformFactory.CreatePlatform();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject platform = collision.gameObject;
            if (platform.CompareTag(platformTag))
            {
                StartCoroutine(HandlePlatform(platform));
            }
        }
    }

    public IEnumerator HandlePlatform(GameObject platform)
    {
        if (platform.transform.position.x <= -14)
        {
            Vector2 position = new Vector2(16f, 14f);
            yield return new WaitForSeconds(5f);
            DespawnPlatform(platform);
            SpawnPlatform(position);
        }
        else
        {
            
            yield return new WaitForSeconds(0.5f);
            Vector2 newPosition = new Vector2(platform.transform.position.x - 6f, 14f);
            SpawnPlatform(newPosition);
            yield return new WaitForSeconds(0.5f);
            DespawnPlatform(platform);
        }
    }
}
