// Written By Terrel
// 3/20/2025
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory Instance { get; private set; }

    public GameObject FrogDudePrefab;
    // TikiGuy is next planned enemy but not implemented yet
    // public GameObject TikiGuyPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public Enemy SpawnEnemy( string enemyType, Vector2 position, float leftBound = 0, float rightBound = 0)
    {
        
        GameObject enemyObject = null;

        switch (enemyType)
        {
            case "FrogDude":
                enemyObject = Instantiate(FrogDudePrefab, position, Quaternion.identity);
                FrogDude frogDude = enemyObject.GetComponent<FrogDude>();
                frogDude.InitializeBounds(leftBound, rightBound);
                break;
            case "TikiGuy":
                //enemyObject = Instantiate(TikiGuyPrefab, position, Quaternion.identity);
                break;
            default:
                Debug.LogError("Unknown enemy type: " + enemyType);
                return null;
        }

        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.Initialize();
        return enemy;
    }


// Start is called before the first frame update
void Start()
    {
        SpawnEnemy("FrogDude",new Vector2(-7, -12), -20, 4 );
    }

}
