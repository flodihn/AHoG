using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    private Transform myTransform;
    public GameObject[] enemyPrefabs;
    public Hero hero;
    public float distanceFromHero;
    public List<GameObject> spawnList = new List<GameObject>();
    public int totalSpawnCount = 10;
    public int spawnGroundEnemiesCount;
    public int spawnRangeEnemiesCount;
    public Vector3 heroPos;
    public bool isHeroInRange = false;


    void Awake()
    {
        myTransform = transform;
    }
        
    // Use this for initialization
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnControl();
        heroPos = hero.transform.position;
    }
    void SpawnControl()
    {
        float distanceFromHero = Vector3.Distance(transform.position, heroPos);

        if (distanceFromHero < 10f)
        {
            if (!isHeroInRange)
            {
                SpawnAllEnemies();
                isHeroInRange = true;
            }
        }
        else
        {
            if(isHeroInRange)
            {
                DestroyAllEnemies();
                isHeroInRange = false;
            }
        }
    }

    void DestroyAllEnemies()
    {

      foreach(GameObject enemyInList in spawnList)
      {
        GameObject.Destroy(enemyInList.gameObject);
      }
     spawnList.Clear();
        
    }
    void SpawnAllEnemies()
    {
        int count = 0;
        while(count < totalSpawnCount)
        {
            SpawnEnemy();
            count++;
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        GameObject prefab = enemyPrefabs[randomIndex];
        GameObject enemy = (GameObject) GameObject.Instantiate(
            prefab,
            transform.position,
            Quaternion.identity);
        spawnList.Add(enemy);
    }
    void Remove()
    {

    }
}
